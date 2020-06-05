<template>
  <div id="app">
    <div id="particles-js">
      <div class="panel" style="display: block">
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
            <small>Eski zamanlarda yaşayan bir Tesadüf Tanrısı vardı. En büyük gücü olan zamanla olağanüstü şeyler
              yaratırdı. Öyle ki insanların bile yapamadığı şeyleri o kolaylıkla yapabiliyordu. Mikrodan makroya gözümüzün
              gördüğü bütün güzellikleri yaratabilecek bir kudreti vardı. O olağanüstü mükemmel tanrının tek bir eksikliği,
              noksanlığı vardı : ZAMAN...
            </small>
            <small
              style="margin-top: 5px; margin-left: 35%; color:rgba(255,255,255,0.32); font-family: 'Comic Sans MS',monospace">
              &copy; made by lâvehn - Source on :
              <a href="https://github.com/aydingltp/coincidence-app" style="color: rgba(255,255,255,0.32)">Github</a>
            </small>
          </div>

        </div>

      </div>



<!--      <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"-->
<!--              integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n"-->
<!--              crossorigin="anonymous"></script>-->
<!--      <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"-->
<!--              integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo"-->
<!--              crossorigin="anonymous"></script>-->
<!--      <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"-->
<!--              integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6"-->
<!--              crossorigin="anonymous"></script>-->


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
  components: {
  },
  created() {
    this.getData()
  }
}
</script>
<!-- particles.js lib (JavaScript CodePen settings): https://github.com/VincentGarreau/particles.js -->


<!--===============================================================================================-->

<style>
#app {

}
</style>
