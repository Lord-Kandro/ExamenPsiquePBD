<?php



var_dump($_POST);




if($Name=== '' || $Surname==='' ||  $Nick==='' || $City==='' || $Department==='' || $Email==='' || $Password=== '' || $cell=== 0  || $IdPerson=== '' || $age ===0){
    echo json_encode ('Llena todos los campos')
} else{
    echo json_encode('Registro completado')
}

?>


