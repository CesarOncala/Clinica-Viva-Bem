const modalEdit = ".modal-content";


document.querySelector("[newItem]").addEventListener('click',()=>{
    
    let form = new FormData();
    form.append("ModalChose","Patient")
    getModal("GetRegisterModal", ".modal-content",form,"POST")
});




//#region DataTable
var table = DataTable("[data-Table]","List",()=>{

    
    document.querySelectorAll(".btnEdit").forEach(o => {
        o.addEventListener('click', (e) => {
          
            let formData = new FormData();
    
            formData.append("id", e.target.getAttribute("data-id"))

            getModal("UpdatePatient", modalEdit, formData, "PUT");

        })})


    document.querySelectorAll(".btnDelete")
    .forEach(o => {
        o.addEventListener('click', (e) => {
            let formData = new FormData();
            formData.append("id", e.target.getAttribute("data-id"))
            SendFecthRequest("RemovePatient", "DELETE", formData, null, null, () => table.ajax.reload(null, false))
        })
    })
})
//#region 