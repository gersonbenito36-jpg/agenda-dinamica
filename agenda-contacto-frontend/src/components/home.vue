<script setup>
import { ref, onMounted } from 'vue';
import FormVue from './FormVue.vue';
import {traerContactos} from '../services/services.js'
import { eliminarContactos } from '../services/services.js';


const formularioActivo = ref(false);
const mostrarFormulario = () => {
    formularioActivo.value = !formularioActivo.value;
};

const contactos = ref([])
const cargarContactos = async () =>{
   const respuesta = await traerContactos()
   contactos.value = respuesta.data
}



const deleteContacto = async(id) =>{
   await eliminarContactos(id)
   await cargarContactos ()
}


const contactoEditar = ref(null)
const abrirFormularioEditar = (contacto)=>{
   contactoEditar.value = contacto
   formularioActivo.value = true
}

onMounted(() =>{
   cargarContactos()
} )


</script>

<template>
   <header class="bg-violet-900 p-8">
      <h1 class="text-white text-3xl
      font-bold text-center">Bienvenido a tu Agenda de contactos</h1>
   </header>
   <div class="w-full bg-violet-300 p-6 flex flex-row justify-around flex gap-8 px-10">
      <input type="text" placeholder="type a name to search on this" name="search"
      class="w-1/2  rounded-md border-2 border-violet-800 focus:outline-none focus:border-violet-600 p-2">
      <button type="button" @click="mostrarFormulario"
      class="bg-violet-900 text-white p-2 border-2 
      border-white px-6 rounded-xl hover:scale-110 transition-transform">
         Agregar +
      </button>
   </div>
   <main class="h-screen bg-gradient-to-bl from-gray-400 via-gra-400y to-gray-400 ">
      <div class="p-8 grid grid-cols-3 gap-8 w-8xl">
         <div v-for="contacto in contactos"
         :key="contacto.id"
         class="bg-violet-300 rounded-xl p-2 flex flex-col items-center hover:scale-105 cursor-pointer shadow-lg shadow-black">
         <div class="w-16 h-16 rounded-full bg-violet-900 flex items-center justify-center font-bold text-lg text-white hover:scale-110 transition-transform shadow-xl">
           {{ contacto.nombre.charAt(0).toUpperCase() }} 
         </div>
         <div class="">
            <p class="text-violet-900 font-bold text-xl">Nombre: {{ contacto.nombre }}</p>
            <p class="text-violet-900 font-bold text-xl">Telefono: {{contacto.telefono}}</p>
            <p class="text-violet-900 font-bold text-xl">Email: {{ contacto.correo }}</p>
         </div>
         <div class="flex items-center justify-between p-2 m-2">
            <button @click="abrirFormularioEditar(contacto)" class="text-white text-sm font-bold bg-blue-600 p-3 rounded-lg mr-2 cursor-pointer hover:scale-110 transition-transform hover:bg-blue-700">Editar</button>
            <button @click="deleteContacto(contacto.id)" class="ml-2 bg-red-700 text-white p-3 rounded-lg text-sm font-bold cursor-pointer hover:scale-110 transition-transform hover:bg-red-800">Eliminar</button>
         </div>

         </div>
      </div>
      <FormVue v-if="formularioActivo" 
      @contactoCreado ="cargarContactos" 
      :contacto = "contactoEditar"
      @cerrar="formularioActivo = false" />
      
   </main>
</template>
