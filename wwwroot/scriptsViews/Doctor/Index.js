
const modalEdit = ".modal-content";


//#region Events
document.querySelector("[btnNew]").
    addEventListener('click', () => {

        let formData = new FormData();
        formData.append("ModalName", "Doctor");

        // GetModal
        getModal("GetRegisterModal", modalEdit, formData, "POST",
            () => {


                document.querySelector("form").addEventListener('submit', (e) => {
                    e.preventDefault();

                    if ($("form").valid()) {
                        SendFecthRequest("AddDoctor", "POST",
                            new FormData(document.querySelector("form")), (e) => {

                                if (e.success){
                                    toastr.success("Save Sucess!")
                                    document.querySelector("[btnClose]").click();
                                }
                                else{
                                    toastr.error("Error to Save!")
                                }

                            }, null, () => {
                                table.ajax.reload(null, false)
                            })
                    }




                });

            });




    })



//#endregion

// #region  DataTable

var table = DataTable("[DataTable]", "List", () => {

    document.querySelectorAll(".btnEdit").forEach(o => {
        o.addEventListener('click', (e) => {

            let formData = new FormData();

            formData.append("id", e.target.getAttribute("data-id"))

            getModal("UpdateDoctor", modalEdit, formData, "PUT", () => {

                document.querySelector("form").addEventListener('submit', (e) => {
                    e.preventDefault();
                    SendFecthRequest("AddDoctor", "POST",
                        new FormData(document.querySelector("form")), (e) => {
                            if (e.success){
                                document.querySelector("[btnClose]").click();
                                toastr.info("Edit Sucess!")
                            }
                            else{
                                toastr.error("Error to Save!")
                            }

                        }, null, () => {
                            table.ajax.reload(null, false)
                        })



                })
            });

        })
    })


    document.querySelectorAll(".btnDelete")
        .forEach(o => {
            o.addEventListener('click', (e) => {
                let formData = new FormData();
                formData.append("id", e.target.getAttribute("data-id"))
                SendFecthRequest("RemoveDoctor", "DELETE", formData, null, null, () => {table.ajax.reload(null, false)
                
                    toastr.warning("The Doctor has been removed!")
                })
            })
        })


});

// #endregion
