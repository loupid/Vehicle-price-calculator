<script setup>
import IftaLabel from 'primevue/iftalabel';
import InputNumber from 'primevue/inputnumber';
import SelectButton from "primevue/selectbutton";
import Divider from "primevue/divider"
import {Form} from "@primevue/forms";
import {reactive, ref, watch} from "vue";

const options = ref(['Common', 'Luxury']);
const initialValues = reactive({
    carPrice: 0
});

function calculateTotal(value) {
}

</script>

<template>
    <div class="flex items-center justify-center min-h-screen p-10 text-black dark:text-white">
        <section class="bg-white dark:bg-surface-900 p-10 rounded-xl flex flex-col gap-8 max-w-3xl">
            <h1 class="text-4xl font-bold text-center">Vehicle price calculator</h1>
            <Form class="flex flex-col gap-4 w-full" v-slot="$form" :initialValues :resolver="calculateTotal">
                <div class="flex flex-col sm:flex-row gap-2">
                    <IftaLabel>
                        <InputNumber input-id="carPrice" name="carPrice" mode="currency" currency="CAD" fluid/>
                        <label for="carPrice">Base price</label>
                    </IftaLabel>
                    <SelectButton name="option" :options="options"/>
                </div>
                <pre class="whitespace-pre-wrap">{{ $form }}</pre>
            </Form>
            <div class="flex flex-col">
                <h2>Fees</h2>
                <Divider></Divider>
                <div class="px-4 items-center flex flex-col sm:flex-row gap-x-4">
                    <h3>Basic : 23</h3>
                    <h3>Special : 23</h3>
                </div>
                <div class="px-4 items-center flex flex-col sm:flex-row gap-x-4">
                    <h3>Association : 23</h3>
                    <h3>Storage : 23</h3>
                </div>
                <Divider/>
            </div>
            <div class="flex flex-col">
                <h2>Total : 92</h2>
            </div>
        </section>
    </div>
</template>