<template>
    <div class="d-flex justify-content-center align-items-center vh-100">
        <div class="card p-4 shadow" style="max-width: 400px;width: 100%">
            <div v-if="mensajeExito" class="alert alert-success text-center">
            {{ mensajeExito }}
            </div>
            <h3 class="text-center">
                Formulario de creaci�n de pa�ses
            </h3>
            <form @submit.prevent="guardarPais">
                <div class="form-group">
                    <label for="nombre">Nombre:</label>
                    <input v-model="datosFormulario.nombre"
                           type="text"
                           id="name"
                           class="form-control"
                           required />
                </div>
                <div class="form-group">
                    <label for="continente">Continente:</label>
                    <select v-model="datosFormulario.continente"
                            id="continente"
                            required
                            class="form-control">
                        <option value="" disabled>
                            Seleccione un
                            continente
                        </option>
                        <option>�frica</option>
                        <option>Asia</option>
                        <option>Europa</option>
                        <option>Am�rica</option>
                        <option>Ocean�a</option>
                        <option>Ant�rtida</option>
                    </select>
                </div>
                <div class="form-group">
                    <label for="idioma">Idioma:</label>
                    <input v-model="datosFormulario.idioma"
                           type="text"
                           id="idioma"
                           class="form-control"
                           required />
                </div>
                <div>
                    <button type="submit" class="btn btn-successbtn-block">
                        Guardar
                    </button>
                </div>
            </form>
        </div>
    </div>
</template>

<script>
  import axios from "axios";
  export default {
    data() {
      return {
        mensajeExito: "",
        datosFormulario: { nombre: "", continente: "", idioma: "" },
      };
    },
    methods: {
      guardarPais() {
        console.log("Datos a guardar:", this.datosFormulario);
        axios.post("https://localhost:7110/api/Paises", {
          nombre: this.datosFormulario.nombre,
          continente: this.datosFormulario.continente,
          idioma: this.datosFormulario.idioma,
        })
        .then((response) => {
          this.mensajeExito = "País agregado correctamente";
          console.log(response);
          setTimeout(() => {
            window.location.href = "/";
          }, 1500);
        })
        .catch((error) => {
          console.log(error);
        });
      },
    },
  };
</script>


<style lang="scss" scoped>
</style>