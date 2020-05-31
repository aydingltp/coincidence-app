<template>
  <div class="container bodycon">
    <h1>Countdown to my birthday:</h1>
    <ul>
      <li><span id="days"></span>days</li>
      <li><span id="hours"></span>Hours</li>
      <li><span id="minutes"></span>Minutes</li>
      <li><span id="seconds"></span>Seconds</li>
    </ul>
  </div>
</template>

<script>
import axios from 'axios';
  export default {
    name: "Coincidence",
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
  * {
    box-sizing: border-box;
    margin: 0;
    padding: 0;
  }

  h1 {
    font-weight: normal;
  }

  li {
    display: inline-block;
    font-size: 1.5em;
    list-style-type: none;
    padding: 1em;
    text-transform: uppercase;
  }

  li span {
    display: block;
    font-size: 4.5rem;
  }

  /* general styling */
  .bodycon {
    height: 100% !important;
    margin: 0;
  }

  .bodycon {
    -webkit-box-align: center;
    -ms-flex-align: center;
    align-items: center;
    background-color: #ffd54f;
    display: -webkit-box;
    display: -ms-flexbox;
    display: flex;
    font-family: -apple-system,
    BlinkMacSystemFont,
    "Segoe UI",
    Roboto,
    Oxygen-Sans,
    Ubuntu,
    Cantarell,
    "Helvetica Neue",
    sans-serif;
  }

  .container {
    color: #333;
    margin: 0 auto;
    padding: 0.5rem;
    text-align: center;
  }


</style>
