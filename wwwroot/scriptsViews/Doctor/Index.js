
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
                        new FormData(document.querySelector("form")), (e) => {
                            
                           if(e.success)
                                document.querySelector("[btnClose]").click();
                        
                        },null,()=>{
                            table.ajax.reload(null, false)
                        })




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

                document.querySelector("#save").addEventListener('click', (e) => {

                    SendFecthRequest("AddDoctor", "POST",
                        new FormData(document.querySelector("form")), (e) => {
                           if(e.success)
                                document.querySelector("[btnClose]").click();
                        
                        },null,()=>{
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
                SendFecthRequest("RemoveDoctor", "DELETE", formData, null, null, () => table.ajax.reload(null, false))
            })
        })


});

// #endregion
