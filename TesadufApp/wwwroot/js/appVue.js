var app = new Vue({
    el: '#app',
    data() {
        return {
            message: "app",
            url: "/home/getdatas",
            i: [],
            yuzyirmi: [],
            item: null,
            gosterilsinmi: false
        };
    },
    methods: {
        getData() {
            setInterval(() => {
                axios.get(this.url, {}).then(obj => {
                    this.yuzyirmi = obj.data;
                    console.log("data geldi");
                    //console.log(obj.data);
                    this.item = 0;
                });
            }, 60000);
        },
        updateData() {
            setInterval(() => {
                this.i = this.yuzyirmi[this.item];
                this.item = this.item + 1;
                //console.log("updatedata= Sayac: " + this.bes.Sayac)
            }, 100);
        },
        doIsLoading() {
            this.gosterilsinmi = true;
            setTimeout(() => {
                this.gosterilsinmi = false;
            }, 1000);
        },
    },
    computed: {
        isLoading() {
            if (this.gosterilsinmi === true) {
                return {
                    display: "block"
                };
            }
            else {
                return {
                    display: "none"
                };
            }
        },
        isPanelLoading() {
            if (this.gosterilsinmi === true) {
                return {
                    display: "none"
                };
            }
            else {
                return {
                    display: "block"
                };
            }
        }
    },
    created() {
        this.doIsLoading();
        axios.get(this.url, {}).then(obj => {
            this.yuzyirmi = obj.data;
        });
        this.getData();
        this.updateData();
    }
})