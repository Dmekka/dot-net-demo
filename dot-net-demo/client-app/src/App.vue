<template>
    <v-app id="inspire">
        <v-app-bar app clipped-left>
            <v-toolbar-title>Popular baby names</v-toolbar-title>
        </v-app-bar>

        <v-main>
            <v-container fluid>
                <PopularBabyNames />
            </v-container>
        </v-main>

        <v-footer app>
            <span>&copy; {{ new Date().getFullYear() }}</span>
        </v-footer>
    </v-app>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import vuetify from '@/plugins/vuetify'; // path to vuetify export
    import PopularBabyNames from './components/PopularBabyNames.vue';

    @Component({
        components: {
            PopularBabyNames,
        },
        props: {
            source: String,
        },
        data: () => ({ }),
        created() {
            this.$vuetify.theme.dark = true;
        },
    })
    export default class App extends Vue { }
</script>

<style>

</style>
