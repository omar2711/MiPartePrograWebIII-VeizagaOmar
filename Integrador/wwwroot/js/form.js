const $formulario = document.querySelector('#formulario');
const $serviceName = document.getElementById('serviceName');
const $serviceDescription = document.getElementById('serviceDescription');
const $servicePrice = document.getElementById('servicePrice');
const $serviceImage = document.getElementById('serviceImage');
const $serviceCategory = document.getElementById('serviceCategory');




(function () {
    $formulario.addEventListener('submit', function (e) {
        let serviceName = String($serviceName.value).trim();
        if (serviceName.length === 0) {
            alert('El nombre del servicio no puede estar vacío');
            e.preventDefault();
        }
    });

    $formulario.addEventListener('submit', function (e) {
        let serviceDescription = String($serviceDescription.value).trim();
        if (serviceDescription.length === 0) {
            alert('La descripción del servicio no puede estar vacía');
            e.preventDefault();
        }
    });
    $formulario.addEventListener('submit', function (e) {
        let servicePrice = String($servicePrice.value).trim();
        if (servicePrice.length === 0) {
            alert('El precio del servicio no puede estar vacío');
            e.preventDefault();
        }
    });
    //$formulario.addEventListener('submit', function (e) {
    //    let serviceImage = String($serviceImage.value).trim();
    //    if (serviceImage.length === 0) {
    //        alert('La imagen del servicio no puede estar vacía');
    //        e.preventDefault();
    //    }
    //}
    $formulario.addEventListener('submit', function (e) {
        let serviceCategory = String($serviceCategory.value).trim();
        if (serviceCategory.length === 0) {
            alert('La categoría del servicio no puede estar vacía');
            e.preventDefault();
        }
    });
})();