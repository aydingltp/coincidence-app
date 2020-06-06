<template>
  <div id="app">
    <div class="loading" :style="isLoading">
      <div class="lds-ripple">
        <div></div>
        <div></div>
      </div>
    </div>
    <div id="particles-js">
      <div class="panel" :style="isPanelLoading">
        <h1 class="baslik">TESADÜF SAYACI</h1>

        <h4>Aranan Cümle : Tesadüf Anlamlı Şeyler Yaratabilir.</h4>
        <div>
          <h4>{{jsondata[1]}}</h4> <h4>Deneme : {{jsondata[0]}} </h4>
        </div>

        <div class="row zaman">
          <div class="col-sm-2">
            <div class="row round">
              {{jsondata[5]}}
            </div>
            <div class="row round">
              <h5><span class="badge badge-info badge-pill">Gün</span></h5>
            </div>
          </div>
          <div class="col tire">:</div>
          <div class="col-sm-2">
            <div class="row round">{{jsondata[4]}}</div>
            <div class="row round">
              <h5><span class="badge badge-info badge-pill">Saat</span></h5>
            </div>
          </div>
          <div class="col tire">:</div>
          <div class="col-sm-2">
            <div class="row round">{{jsondata[3]}}</div>
            <div class="row round">
              <h5><span class="badge badge-info badge-pill">Dakika</span></h5>
            </div>
          </div>
          <div class="col tire">:</div>
          <div class="col-sm-2">
            <div class="row round">{{jsondata[2]}}</div>
            <div class="row round">
              <h5><span class="badge badge-info badge-pill">Saniye</span></h5>
            </div>
          </div>
          <div class="row description">
            <div class="scroll-up">
              <p>Eski zamanlarda yaşayan bir Tesadüf Tanrısı vardı. <br> En büyük gücü olan zamanla olağanüstü şeyler
                yaratırdı. <br> Öyle ki insanların bile yapamadığı şeyleri o kolaylıkla yapabiliyordu. <br> Mikrodan makroya gözümüzün
                gördüğü bütün güzellikleri yaratabilecek bir kudreti vardı. <br> O olağanüstü mükemmel tanrının tek bir eksikliği,
                noksanlığı vardı : <br> ZAMAN...
              </p>
            </div>
            <small
              style="margin-top: 5px; margin-left: 35%; color:rgba(255,255,255,0.32); font-family: 'Comic Sans MS',monospace">
              &copy; made by lâvehn - Source on :
              <a href="https://github.com/aydingltp/coincidence-app" style="color: rgba(255,255,255,0.32)">Github</a>
            </small>
          </div>


        </div>

      </div>

    </div>
  </div>
</template>


<script>
  import axios from 'axios';
export default {
  name: 'app',
  data () {
    return {
      data1: null,
      url: "https://localhost:5001/api/tesaduf",
      jsondata: []
    }
  },
  methods: {
    getData() {
      this.data1 = setInterval(() => {
        axios.get(this.url, {}).then(obj => {
          this.jsondata = obj.data;
          //console.log(obj.data);
        })
      }, 1000)
    }
  },
  computed:{
    isLoading(){
      if (this.jsondata[0]==null){
          return {
            display: "block"
          }
      }
      else{
        return {
          display: "none"
        }
      }
    },
    isPanelLoading(){
      if (this.jsondata[0]==null){
        return {
          display: "none"
        }
      }
      else{
        return {
          display: "block"
        }
      }
    }

  },
  created() {
    this.getData()
  }

}
</script>
<style>
#app {

}
</style>
