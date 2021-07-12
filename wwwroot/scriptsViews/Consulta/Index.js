const select2config = (typeSearch) => {
    return {
        width: "100%",
        minimumInputLength: 3,
        placeholder: 'Type Here',
        allowClear: true,
        ajax: {
            url: window.location.pathname + "/GetSelectOptions",
            delay: 250,
            data: function (params) {
                var query = {
                    search: params.term,
                    page: params.page || 1,
                    typeSearch: typeSearch
                }
                return query;
            },
            processResults: function (data, params) {
                params.page = params.page || 1;
                return {
                    results: data.results,
                    pagination: {
                        more: (params.page * 10) < data.count_filtered
                    }
                };
            }
        },

    }
}

//#region New Consultation
document.querySelector("[data-add]").
    addEventListener('click', (e) => {

        // GetModal
        getModal("GetModalEdit", ".modal-content", null, "POST",
            () => {

                $("#DoctorId").select2(select2config("doctor"))

                $("#PatientId").select2(select2config("patient"));

                document.querySelector("[EditConsultation]").addEventListener('submit', (e) => {
                    e.preventDefault();

                    data = new FormData(document.querySelector("[EditConsultation]"))

                    if ($("[EditConsultation]").valid()) {
                        SendFecthRequest("EditConsulta", "POST",
                            data, (e) => {
                                console.log(e)
                                if (e.success) {
                                    toastr.success("Success Writen!")
                                    document.querySelector("[btnClose]").click();
                                }
                                else {
                                    toastr.error(e.message)
                                };

                            }, null, () => {
                                table.ajax.reload(null, false)
                            })
                    }

                });

            });

    });

//#endregion

// #region  DataTable


var table = DataTable("[DataTable]", "List", () => {

    document.querySelectorAll(".btnEdit").forEach(o => {
        o.addEventListener('click', (e) => {

            let formData = new FormData();
            formData.append("id", e.target.getAttribute("data-id"))

            getModal("GetModalEdit", ".modal-content", formData, "POST", () => {

                $("#DoctorId").select2(select2config("doctor"))

                $("#PatientId").select2(select2config("patient"));


                document.querySelector("[EditConsultation]").addEventListener('submit', (e) => {
                    e.preventDefault();

                    if ($("[EditConsultation]").valid()) {
                        SendFecthRequest("EditConsulta", "POST",
                            new FormData(document.querySelector("[EditConsultation]")), (e) => {
                                console.log(e)
                                if (e.success) {
                                    toastr.info("Success Edit!")
                                    document.querySelector("[btnClose]").click();
                                }
                                else {
                                    toastr.error(e.message)
                                }

                            }, null, () => {
                                table.ajax.reload(null, false)
                            })
                    }


                })
            });

        })
    })


    document.querySelectorAll(".btnDelete")
        .forEach(o => {
            o.addEventListener('click', (e) => {
                let formData = new FormData();
                formData.append("id", e.target.getAttribute("data-id"))
                SendFecthRequest("RemoveConsulta", "DELETE", formData, null, null, (e) => {
                    table.ajax.reload(null, false)

                    toastr.warning("The Consult has been deleted!")
                })
            })
        })


},
// For the DataTable Plugins we need use JQuery Serialize
function ( d ) {
    d.Patient =   document.querySelector("#Patient").value
    d.Doctor =  document.querySelector("#Doctor").value
    d.DateStart = document.querySelector("#DateStart").value,
    d.DateEnd = document.querySelector("#DateEnd").value
},
);



// #endregion


//#region Filters

document.querySelector("[btnFilter]").addEventListener('click', () => table.ajax.reload(null, false));
// document.querySelectorAll("[filterInput]").forEach(o=> o.addEventListener('keyup',()=>{
//     table.ajax.reload(null, false)
// }))
document.querySelector("[clearFilters]").addEventListener('click',()=>{
    document.getElementById("filters").reset();
    table.ajax.reload(null,false);
})




//#endregion
