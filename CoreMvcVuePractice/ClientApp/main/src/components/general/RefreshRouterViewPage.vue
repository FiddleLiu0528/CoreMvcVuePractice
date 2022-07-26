<template>refreshing</template>

<script lang="ts">
export default {
  beforeRouteEnter(to: any, from: any, next: any) {
    next((vm: any) => {
      vm.$router.replace(from.path);
    });
  },
};
</script>
