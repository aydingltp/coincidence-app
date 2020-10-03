var app = new Vue({
    el: '#app',
    data() {
        return {
            message: "app",
            data1: null,
            url: "/home/getdatas",
            bes: [],
            yuzyirmi: [],
            item: 0,
            screenReady: false
        }
    },
    methods: {
        getData() {
            setInterval(() => {
                axios.get(this.url, {}).then(obj => {
                    this.yuzyirmi = null;
                    this.yuzyirmi = obj.data;
                    console.log("data geldi");
                    this.item = 0;
                })
            }, 30000)
        },
        updateData() {
            setInterval(() => {
                this.bes = this.yuzyirmi[this.item];
                this.item = this.item + 1;
                //console.log("updatedata= Sayac: " + this.bes.Sayac)
            }, 200)
        }
    },
    computed: {
        isLoading() {
            if (this.screenReady == false) {
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
            if (this.screenReady == false) {
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
        this.getData();
        this.updateData();
        axios.get(this.url, {}).then(obj => {
            this.yuzyirmi = null;
            this.yuzyirmi = obj.data;
            this.screenReady = true;
        })
    }
})