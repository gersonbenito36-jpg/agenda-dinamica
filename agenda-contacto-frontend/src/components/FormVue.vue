<script setup>
import { ref } from 'vue';
import { watch } from 'vue';
import { crearContactos } from '../services/services.js';
import { actualizarContactos} from '../services/services.js';

const propiedades =defineProps({  //está vinculado con el watch
    contacto: Object
})

const emit = defineEmits(['cerrar', 'contactoCreado'])
const nombre = ref('')
const telefono = ref('')
const correo = ref('')

watch(() => propiedades.contacto, (nuevoContacto) => {
    if (nuevoContacto){
        nombre.value = nuevoContacto.nombre
        telefono.value = nuevoContacto.telefono
        correo.value = nuevoContacto.correo
    } else{
        nombre.value = ''
        telefono.value = ''
        correo.value = ''
    }
}, {immediate : true })

const registrarContacto = async() =>{
    if (propiedades.contacto)  {
        await actualizarContactos (propiedades.contacto.id, {
            id: propiedades.contacto.id,
            nombre: nombre.value, 
            telefono: telefono.value,
            correo: correo.value
        })

       
    } else{
        await crearContactos({
            nombre: nombre.value,
            telefono: telefono.value,
            correo: correo.value
        })
    }
    emit('contactoCreado')
    emit('cerrar')
}
</script>


<template>
<div class="fixed inset-0 bg-slate-800 bg-opacity-20 flex items-center justify-center">
    <form 
    class="bg-white rounded-xl w-96 p-10  flex flex-col gap-2 border-2 border-violet-400">
    <div class="flex justify-end"> 
    <button type="button" class="text-red-500 font-bold hover:bg-red-600 hover:cursor-pointer  hover:text-white p-2 rounded-md " @click="emit('cerrar')">Cerrar</button>
    </div>
    
        <label for="nombre" class="font-bold text-md text-violet-800 ">Nombre de contacto</label>
        <input v-model="nombre" type="text"  class="font-bold text-md text-violet-600 border-2 border-violet-500
        focus:outline-none  focus:border-violet-400 p-2 rounded-md " placeholder="Nombre"  >

        <label for="email " class="font-bold text-md text-violet-800">Email contacto</label>
        <input v-model="correo" type="email" class="font-bold text-md text-violet-600 border-2 border-violet-500
        focus:outline-none focus:border-violet-500 p-2 rounded-md" placeholder="Email">

        <label for="telefono" class="font-bold text-md text-violet-800" >Telefono</label>
        <input v-model="telefono" type="telefono"  class="font-bold text-md text-violet-600 border-2 border-violet-500 
        focus:outline-none focus:border-violet-500 p-2 rounded-md" placeholder="Teléfono">
        
        <div class="flex flex-row justify-center">
            <button type="button" @click="registrarContacto" class=" bg-violet-700 font-bold text-white m-2 p-2 w-full m-0 rounded-xl 
            cursor-pointer hover:scale-110 transition-transform mt-8 hover:bg-violet-800 hover:text-white">Registrar contacto</button>
        </div>
    </form>
</div>
</template>