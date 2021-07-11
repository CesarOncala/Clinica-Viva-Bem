// #region Consts
const getModal = (ActionName, contentSelector, formData, method, funcAfterLoad) => {

    fetch(`${window.location.pathname}/${ActionName}`, {
        method: method == null ? "POST" : method,
        body: formData
    }).then(result => result.text())
        .then(result => {
            let section = document.querySelector(contentSelector);
            section.innerHTML = result;

            $(".modal").modal("show");
            var $form = $('form');
            $.validator.unobtrusive.parse($form);
        })
        .finally(result => (funcAfterLoad == null ? () => { } : funcAfterLoad()))

}

const SendFecthRequest = (ActionName, method, data, successFunc, errorFunc, completeFunc) => {

    let url = !ActionName.includes("/") ? `${window.location.pathname}/${ActionName}` : ActionName
    fetch(url, {
        method: method,
        body: data,
    })
        .then(result => result.json())
        .then(successFunc == null ? () => { } : successFunc)
        .catch(errorFunc == null ? () => { } : errorFunc)
        .finally(completeFunc == null ? () => { } : completeFunc);

}


const DataTable = (selector, ActionName, completeFunc) => {
    return $(selector).DataTable({
        ajax: {
            url: `${window.location.pathname}/${ActionName}`,
            method: "GET",
            async: true,
            complete: completeFunc,
        },
        width: 100,
        "bProcessing": true,
        dom: 'Bfrtip',
        buttons: [

            'copyHtml5',
            'excelHtml5',
            'csvHtml5',
            'pdfHtml5',
            'print'
            // customize: function ( doc ) {
            //     doc.content.splice( 0, 0, {
            //         text: document.location.pathname
            //     } );
            // }
        ],

    });
}

// #endregion