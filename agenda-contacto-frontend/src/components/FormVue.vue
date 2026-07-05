<script setup>
const emit = defineEmits(['cerrar'])
</script>


<template>
<div class="fixed inset-0 bg-slate-800 bg-opacity-20 flex items-center justify-center">
    <form action="submit" 
    class="bg-white rounded-xl w-96 p-10  flex flex-col gap-6">
    <div class="flex justify-end"> 
    <button type="button" class="text-red-500 " @click="emit('cerrar')">Cerrar</button>
    </div>
    
        <label for="nombre" class="font-bold text-md text-red-500">Nombre de contacto</label>
        <input type="text" class="font-bold text-md text-red-500 " placeholder="Nombre">
        <label for="email">Email contacto</label>
        <input type="email" class="font-bold text-md text-red-500" placeholder="Email">
        <label for="telefono">Telefono</label>
        <input type="tel" class="font-bold text-md text-red-500" placeholder="Teléfono">
        <button type="submit">Agregar Contacto</button>
        <div class="flex flex-row justify-center">
            <button class=" bg-sky-400 m-2 p-2 w-full m-0 rounded-xl cursor-pointer hover:scale-110 transition-transform hover:bg-sky-600">Registrar contacto</button>
        </div>
    </form>
</div>
</template>