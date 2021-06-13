import * as Vue from 'vue/dist/vue.esm-bundler';

const Hello = {
  props: ['greeting'],
  template: `
    <p>{{ greeting }}!</p>
  `,
};

const Number = {
  props: ['num'],
  template: `
    <button @click="choose" :class="isEven(num) ? 'blue': 'red'">{{ num }}</button>
    <span v-if="isEven(num)" :class="isEven(num) ? 'blue': 'red'">is even number</span>
    <span v-else>is odd odd number</span>
  `,
  methods: {
    isEven(number: number) {
      return number % 2 === 0;
    },
    choose() {
      this.$emit('chosen', this.num);
    },
  },
};

const app = Vue.createApp({
  components: {
    Hello,
    Number,
  },
  template: `
    <hello greeting="hello component hello"/>
    <h1 @click="increment">{{ text }}{{ count }}</h1>
    <div v-if="even">is even</div>
    <div v-else>is odd</div>
    {{ chosenNumber }}
    <div v-for="number in numbers">
      <number :num="number" @chosen="chosen"/>
    </div>
    <h3>even list</h3>
    <number :num="number" v-for="number in evenList" @chosen="chosen" />
    <div>{{ error }}</div>
    <input v-bind:value="value" v-on:input="input" />
    <div>{{ value }}</div>
    <div>{{ radioValue }}</div>
    <input type="radio" v-model="radioValue" value="a" />
    <input type="radio" v-model="radioValue" value="b" />
    <input type="radio" v-model="radioValue" value="c" />
    <div>{{ checkValue }}</div>
    <input type="checkbox" v-model="checkValue" value="a" />
    <input type="checkbox" v-model="checkValue" value="b" />
    <input type="checkbox" v-model="checkValue" value="c" />
  `,
  data() {
    return {
      text: 'hello typescript',
      count: 0,
      numbers: [1, 2, 3, 4, 5, 6, 7, 8, 9],
      value: 'diego',
      radioValue: 'a',
      checkValue: ['a'],
      chosenNumber: 0,
    };
  },
  computed: {
    even() {
      return this.count % 2 === 0;
    },
    evenList() {
      return this.numbers.filter(this.isEven);
    },
    error() {
      if (this.value.length < 5) {
        return 'must be greater than 5';
      }
    },
  },
  methods: {
    increment() {
      this.count += 1;
    },
    isEven(number: number) {
      return number % 2 === 0;
    },
    input($event) {
      this.value = $event.target.value;
    },
    chosen(num: number) {
      this.chosenNumber = num;
    },
  },
});
app.mount('#app');
