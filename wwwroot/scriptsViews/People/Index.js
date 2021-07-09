
const modalEdit = ".modal-content";


//#region Events
document.querySelector("[btnNew]").
    addEventListener('click', () => {
        let formData = new FormData();
        formData.append("ModalName", "Doctor");

        // GetModal
        getModal("GetRegisterModal", modalEdit, formData, "POST",
            () => {

                document.querySelector("#save").addEventListener('click', (e) => {

                    SendFecthRequest("AddDoctor", "POST",
                        new FormData(document.querySelector("form")), null, null,
                        () => table.ajax.reload(null, false))


                    document.querySelector("[btnClose]").click();

                });

            });




    })



//#endregion

// #region  DataTable

var table = DataTable("[DataTable]", "List", () => {

    let formData = new FormData();

    document.querySelectorAll(".btnEdit").forEach(o => {
            o.addEventListener('click', (e) => {
              
                formData.append("id", e.target.getAttribute("data-id"))

                getModal("UpdateDoctor", modalEdit, formData, "PUT", () => {

                    document.querySelector("#save").addEventListener('click', (e) => {

                        SendFecthRequest("AddDoctor", "POST",
                            new FormData(document.querySelector("form")), null, null,
                            () => table.ajax.reload(null, false))


                        document.querySelector("[btnClose]").click();
                    })
                });

            })})


    document.querySelectorAll(".btnDelete")
        .forEach(o => {
            o.addEventListener('click', (e) => {
                formData.append("id", e.target.getAttribute("data-id"))
                SendFecthRequest("RemoveDoctor", "DELETE", formData, null, null, () => table.ajax.reload(null, false))
            })
        })


});

// #endregion
