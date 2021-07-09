// #region Consts
const getModal =  (ActionName,contentSelector,formData,method,funcAfterLoad)=>{

        fetch(`${window.location.pathname}/${ActionName}`,{
            method: method == null ? "POST" : method,
            body: formData
        }).then(result=> result.text())
        .then(result=>{
            document.querySelector(contentSelector).innerHTML = result;
            $(".modal").modal("show");
        })
        .finally(result=> (funcAfterLoad == null? ()=>{}: funcAfterLoad()))
            
}

const SendFecthRequest = (ActionName,method,data,successFunc,errorFunc,completeFunc)=>{

    let url =  !ActionName.includes("/")? `${window.location.pathname}/${ActionName}` : ActionName
    fetch(url,{
        method: method,
        body: data,
    })
    .then(result=> result.json())
    .then(successFunc == null ? ()=> {} : successFunc)
    .catch(errorFunc == null ? ()=> {} : errorFunc)
    .finally(completeFunc == null ? ()=>{}: completeFunc);

}


const DataTable = (selector,ActionName,completeFunc) =>{
   return $(selector).DataTable({
        ajax:  {
            url: `${window.location.pathname}/${ActionName}`,
            method: "GET",
            async: true,
            complete: completeFunc,
        }

    });
}

// #endregion