// María Fernanda Herrera Gutiérrez C13747

// Método para agregar un nuevo elemento a la lista
function agregar() {
  var lista = document.getElementById("lista");
  // Crear un nuevo elemento de lista
  var nuevo_elemento = document.createElement("li");
  // Obtener la cantidad de elementos en la lista
  var contar_elementos = lista.getElementsByTagName("li").length;
  // Nombrar el nuevo elemento con el número correspondiente
  nuevo_elemento.innerHTML = "Elemento " + (contar_elementos + 1);
  lista.appendChild(nuevo_elemento);
}

// Método para cambiar el color de fondo de la página
function cambiarFondo() {
  if (document.body.style.backgroundColor == "white") {
    // Si el color de fondo es blanco, cambiar a celeste
    document.body.style.backgroundColor = "lightblue";
  }
  else {
    // Si el color de fondo es celeste, cambiar a blanco
    document.body.style.backgroundColor = "white";
  }
}

// Método para borrar el último elemento de la lista
function borrar() {
  var lista = document.getElementById("lista");
  // Verificar que haya al menos un elemento en la lista
  if (lista.getElementsByTagName("li").length > 0) {
    lista.removeChild(lista.lastChild);
  }
}
