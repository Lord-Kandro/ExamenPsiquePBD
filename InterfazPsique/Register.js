
var formulario = document.getElementById('formulario');

formulario.addEventListener('submit', function(e){
    e.preventDefault();
    
    var datos = new FormData(formulario);
    
    peticion  = {
        method: 'POST',
        body: datos
    }
    fetch('php/postUser.php', peticion)
        .then(res =>  res.json())
        .then(res => {
            console.log(data)
    })
    .catch(error => console.log('error', error));
})

