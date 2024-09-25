<script setup>
import IftaLabel from 'primevue/iftalabel';
import InputNumber from 'primevue/inputnumber';
import SelectButton from "primevue/selectbutton";
import Divider from "primevue/divider"
import {reactive, ref, watch} from "vue";
import BasePrice from "@/components/BasePrice.vue";

const vehicleTypes = ref(['Common', 'Luxury']);
const initialValues = reactive({
    basePrice: 0,
    vehicleType: 'Common'// default
});

const fees = reactive({
    basic: 0,
    special: 0,
    association: 0,
    storage: 0,
    total: 0
});

const PRICE_CALCULATOR_URL = '/pricecalculator';
const HEADERS = {
    'Content-Type': 'application/json',
};

async function fetchPriceData(body) {
    let response = await fetch(PRICE_CALCULATOR_URL, {
        method: 'POST',
        headers: HEADERS,
        body: JSON.stringify(body)
    });
    return await response.json();
}

function calculateFees(values) {
    if (values.basePrice == null || values.vehicleType == null || values.basePrice <= 0 || values.vehicleType === '') {
        return;
    }
    const body = {
        BasePrice: values.basePrice,
        VehicleType: values.vehicleType
    };
    fetchPriceData(body).then(data => {
        fees.basic = data.basic;
        fees.special = data.special;
        fees.association = data.association;
        fees.storage = data.storage;
        fees.total = data.total;
    });
}

watch(initialValues, (values) => {
    calculateFees(values);
    },
    {
        //
        deep: true
    }
);

</script>

<template>
    <div class="flex items-center justify-center min-h-screen p-10 text-black dark:text-white">
        <section class="bg-white dark:bg-surface-900 p-10 rounded-xl flex flex-col gap-8 max-w-3xl">
            <h1 class="text-4xl font-bold text-center">Vehicle price calculator</h1>
            <div class="flex flex-col gap-4 w-full">
                <div class="flex flex-col sm:flex-row gap-2">
                    <IftaLabel>
                        <InputNumber v-model="initialValues.basePrice" currency="CAD" fluid
                                     input-id="basePrice" mode="currency" name="basePrice"/>
                        <label for="basePrice">Base price</label>
                    </IftaLabel>
                    <SelectButton v-model="initialValues.vehicleType" :options="vehicleTypes" name="vehicleType"/>
                </div>
            </div>
            <div class="flex flex-col">
                <h2>Fees</h2>
                <Divider/>
                <div class="px-4 place-items-center sm:place-items-stretch grid grid-cols-1 sm:grid-cols-2 gap-x-4">
                    <BasePrice name="Basic" :price="fees.basic"/>
                    <BasePrice name="Special" :price="fees.special"/>
                    <BasePrice name="Association" :price="fees.association"/>
                    <BasePrice name="Storage" :price="fees.storage"/>
                </div>
                <Divider/>
            </div>
            <div class="flex flex-col">
                <BasePrice name="Total" :price="fees.total"/>
            </div>
        </section>
    </div>
</template>