var app = new Vue({
    el: '#app',
    data() {
        return {
            message: "app",
            data1: null,
            url: "/home/getdata",
            bes: []
        }
    },
    methods: {
        getData() {
            this.data1 = setInterval(() => {
                axios.get(this.url, {}).then(obj => {
                    this.bes = obj.data;
                    //console.log(obj.data);
                })
            }, 250)
        }
    },
    computed: {
        isLoading() {
            if (this.bes[0] == null) {
                return {
                    display: "block"
                }
            }
            else {
                return {
                    display: "none"
                }
            }
        },
        isPanelLoading() {
            if (this.bes[0] == null) {
                return {
                    display: "none"
                }
            }
            else {
                return {
                    display: "block"
                }
            }
        }

    },
    created() {
        this.getData()
    }
}) 