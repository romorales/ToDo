import { createStore } from 'vuex'

const store = createStore({
    strict: true,
    state: {
    listaTareas: []
  },
  mutations: {
    agregarTarea (state, {id,nombre,estado}) {
        state.listaTareas.push({id,nombre,estado});
    },
    cambiarEstadoTarea (state, id) {
      for (let tarea of state.listaTareas) {
        if (tarea.id === id[0]) {
          tarea.estado = !tarea.estado;
        }
        }
      },
    updateData (state,item){
        state.listaTareas = item;
    },
    eliminarTarea (state, id) {
        let index = '';
        state.listaTareas.forEach(function (tarea, i) {
            if (tarea.id === id[0]) 
            {
                index = i;
            }
        });
       
        state.listaTareas.splice(index,1);
      },
  },
  actions: {
    triggerFunction: (context, {id,nombre,estado}) => {
        context.commit('agregarTarea', {id,nombre,estado})
    }
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