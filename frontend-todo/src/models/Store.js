import { createStore } from 'vuex'
import axios from  "axios";
const url = "http://localhost:5288/api/"
const store = createStore({
    strict: true,
    state: {
    listaTareas: []
  },
  mutations: {
    getTareas (state, tarea){
      state.listaTareas = tarea;
    },
  },
  actions: {
    async triggerAgregarTarea (context, tarea) {
     await axios.post(url + "Tarea/", tarea).then(respuesta => {
         console.log(respuesta);
         return context.dispatch('triggerGetTareas');
        }).catch(error => {
                  console.log(error)
        })
    },
    async triggerGetTareas (context) {
       return axios.get(url + "Tarea").then(respuesta => {
           context.commit('getTareas', respuesta.data);
      }).catch(error => {
        console.log(error)
      })
    },
    async triggerEliminarTarea (context, id) {
      await axios.delete(url + "Tarea/" + id).then(respuesta => {
        console.log(respuesta);
        return context.dispatch('triggerGetTareas');
      }).catch(error => {
                console.log(error)
      })
    },
    async triggerCambiarEstadoTarea (context, {id, tarea}) {
      await axios.put(url + "Tarea/" + id, tarea).then(respuesta => {
        console.log(respuesta);
        return context.dispatch('triggerGetTareas');
      }).catch(error => {
        console.log(error)
      })
    },
  },
  getters: {
    getPendientes:state => {
        let pendientes = [];
        for (let tarea of state.listaTareas) {
            if(tarea.estado == false)
            {
                pendientes.push(tarea);
            }
         }
        
        return pendientes;
    },
    getCompletadas: state => {
        let completadas = [];
        for (let tarea of state.listaTareas) {
            if(tarea.estado == true)
            {
                completadas.push(tarea);
            }
        }
        return completadas;
    }
  },
});

export default store;