import * as Vue from 'vue/dist/vue.esm-bundler';

const app = Vue.createApp({
  template: `
    <h1 @click="increment">{{ text }}{{ count }}</h1>
  `,
  data() {
    return {
      text: 'hello typescript',
      count: 0,
    };
  },
  methods: {
    increment() {
      this.count += 1;
    },
  },
});
app.mount('#app');
