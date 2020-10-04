//import moment from 'moment' 

//Vue.filter('formatDate', function (value) {
//    if (value) {
//        return moment(String(value)).format('00')
//    }
//}
//import numeral from 'numeral.js';
//import numFormat from 'vue-filter-number-format';

//Vue.filter('numFormat', numFormat(numeral));

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
            screenReady: false,
            sayi: 123456789
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
            if (this.bes == null) {
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
            if (this.bes == null) {
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
        });
        //console.log(new Intl.NumberFormat().format(this.sayi))
    }
    //filters: {
    //    toTime(value) {
    //        return `0${value}`
    //    },
    //    toLongNumber(value) {
    //        return `00${value}`
    //    },
    //}
})