<script setup>
defineProps(['name', 'price']);

function currencyFormat(price) {
    return price.toFixed(2);
}
</script>

<template>
    <h3>{{name}} : {{currencyFormat(price)}} $</h3>
</template>