function llenar_ceros_cadena(cadena, caracter_separador) {
    var porciones = cadena.split(caracter_separador);
    var contar_porcion = 0;
    porciones.forEach(function (porcion) {
        if (porciones[contar_porcion].length == "1") porciones[contar_porcion] = "0" + porciones[contar_porcion];
        contar_porcion++;
    });
    cadena = porciones.join(caracter_separador);
    return cadena;
}