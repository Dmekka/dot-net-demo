<template>
    <div class="section">
        <v-card>
            <v-card-title>
                City of Austin (2008 - 2017)
                <v-spacer></v-spacer>
                <v-text-field v-model="search"
                              append-icon="mdi-magnify"
                              label="Search"
                              single-line
                              hide-details>
                </v-text-field>
            </v-card-title>
            <v-data-table dense 
                          :headers="headers"
                          :items="babyNames"
                          :search="search"
                          item-key="Id"
                          sort-by="Rank"
                          group-by="Year"
                          group-desc
                          class="elevation-1"
                          :loading="loading" loading-text="Loading... Please wait"
                          show-group-by>

            </v-data-table>
        </v-card>
    </div>
</template>

<script lang="ts">
    import Vue from 'vue';
    import 'isomorphic-fetch';

    export default Vue.extend({
        methods: {
        },
        data() {
            return {
                loading: true,
                jsonResult: {},
                babyNames: [] as string[],
                search: '',
                headers: [
                    { text: 'Year', value: 'Year', align: 'start' },
                    { text: 'Rank', value: 'Rank' },
                    { text: 'Boy', value: 'NameBoy' },
                    { text: 'Girl', value: 'NameGirl' },
                ],
            };
        },
        async created() {
            const r = await fetch('/api/names');
            this.jsonResult = await r.json();
            this.babyNames = this.jsonResult.data;
            this.loading = false;
        },
    });
</script>
