<template>
  <div>
    <div class="card-body">
            <h1 v-show="Array.isArray(listaTareasPendientes) && listaTareasPendientes.length !== 0" class="display-6 text-center" >Por hacer</h1>
            <ul class="list-group">
              <li v-for="(tarea, index) of listaTareasPendientes" :key="index" class="list-group-item d-flex justify-content-between">
                <span class="cursor" v-on:click="marcarTareaResuelta(tarea.id)">
                  <i class="fa-regular fa-circle"></i>
                </span>
                 {{ tarea.nombre }}
               <span class="text-danger cursor"  v-on:click="eliminarTarea(tarea.id)">
                <i class="fas fa-trash"></i>
                </span>
              </li>
            </ul>
      </div>
   </div>
</template>

<script>
  export default {
    name: 'PendientesComponent',

    props:['listaTareas'],

    computed: {  
      listaTareasPendientes(){
        let lista = [];
        for(let i = 0; i < this.listaTareas.length; i++)
        {
          let tarea = {
            id: i,
            nombre: this.listaTareas[i].nombre
          }

          if (this.listaTareas[i].estado == false)
          {
            lista.push(tarea); 
          }
        } 
        return lista;
      }
    },

    methods: {
      marcarTareaResuelta(id){
        this.$emit('marcarTareaResuelta', [id]);
      },
      eliminarTarea(id){
        this.$emit('eliminarTarea', [id]);
      },
    }
  }
</script>

<style scoped>
.cursor{
  cursor: pointer;
}
</style>