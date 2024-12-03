<script setup>
import IftaLabel from 'primevue/iftalabel';
import InputNumber from 'primevue/inputnumber';
import SelectButton from "primevue/selectbutton";
import Divider from "primevue/divider"
import {reactive, ref, watch} from "vue";

const options = ref(['Common', 'Luxury']);
const initialValues = reactive({
    carPrice: 0,
    option: 'Common'
});

const fees = reactive({
    basic: 0,
    special: 0,
    association: 0,
    storage: 0,
    total: 0
});

function calculateTotal(values) {
    if (values.carPrice <= 0) {
        return;
    }

    const body = {
        BasePrice: values.carPrice,
        VehicleType: values.option
    }

    fetch('/pricecalculator', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(body)
    })
        .then(data => data.json())
        .then(data => {
            fees.basic = data.basic.toFixed(2);
            fees.special = data.special.toFixed(2);
            fees.association = data.association.toFixed(2);
            fees.storage = data.storage.toFixed(2);
            fees.total = data.total.toFixed(2);
        });
}

watch(initialValues, (values) => {
    calculateTotal(values)
}, {deep: true});

</script>

<template>
    <div class="flex items-center justify-center min-h-screen p-10 text-black dark:text-white">
        <section class="bg-white dark:bg-surface-900 p-10 rounded-xl flex flex-col gap-8 max-w-3xl">
            <h1 class="text-4xl font-bold text-center">Vehicle price calculator</h1>
            <div class="flex flex-col gap-4 w-full">
                <div class="flex flex-col sm:flex-row gap-2">
                    <IftaLabel>
                        <InputNumber v-model="initialValues.carPrice" currency="CAD" fluid
                                     input-id="carPrice" mode="currency" name="carPrice"/>
                        <label for="carPrice">Base price</label>
                    </IftaLabel>
                    <SelectButton v-model="initialValues.option" :options="options" name="option"/>
                </div>
            </div>
            <div class="flex flex-col">
                <h2>Fees</h2>
                <Divider></Divider>
                <div class="px-4 items-center flex flex-col sm:flex-row gap-x-4">
                    <h3>Basic : {{ fees.basic ?? 0 }} $</h3>
                    <h3>Special : {{ fees.special ?? 0}} $</h3>
                </div>
                <div class="px-4 items-center flex flex-col sm:flex-row gap-x-4">
                    <h3>Association : {{ fees.association ?? 0}} $</h3>
                    <h3>Storage : {{ fees.storage ?? 0}} $</h3>
                </div>
                <Divider/>
            </div>
            <div class="flex flex-col">
                <h2>Total : {{ fees.total }} $</h2>
            </div>
        </section>
    </div>
</template>