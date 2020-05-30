<template>
  <div class="kutu">
    <div class="count1">
      <div>{{jsondata[5] | zaman}} </div>
      <div>:</div>
      <div>{{jsondata[4] | zaman}}</div>
      <div>:</div>
      <div>{{jsondata[3] | zaman}}</div>
      <div>:</div>
      <div>{{jsondata[2] | zaman}}</div>
    </div>
    <div class="count2">
      <div> Gün</div>
      <div> Saat</div>
      <div> Dakika</div>
      <div> Saniye</div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
  export default {
    name: "Countdown",
    data(){
      return{
        data1:null,
        url:"https://localhost:5001/api/tesaduf",
        jsondata:[]
      }
    },
    methods: {
      getData() {
          this.data1 = setInterval(()=>{
            axios.get(this.url, {
            }).then(obj => {
              this.jsondata =obj.data;
            })
        },1000)
      }
    },
    actions:{

    },
    created() {
      this.getData()
    }

  }

</script>

<style scoped>
  .kutu{
    padding-top: 9%;
  }
  .count1 div{
    display: inline;
    margin-right: 2%;

    color: #f7f7f7;
    font-size: 5vw;
    font-weight: bold;
  }
  .count2{
    text-align: center;
    margin-top:1px;
    margin-left: 7%;
  }
  .count2 div{
    display: inline;
    margin-right: 9%;
    color: #f7f7f7;
    font-size: 1vw;
    font-weight: bold;
  }



</style>
