
document.querySelector("[data-add]").
    addEventListener('click', (e) => {

        fetch(document.location.pathname + "/GetModals").
        then(o=> o.text())
        .then(o=>{
            console.log(o)
            document.querySelector(".modal-content").innerHTML = o;
            $(".modal").modal("show");
        })
    });

  