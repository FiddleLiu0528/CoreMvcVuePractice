import { computed, Ref } from "vue";

export default function (breadcrumbList: Ref<string[]>, nowLayerIndex: number) {
  const PreviousLayer = () => {
    breadcrumbList.value.pop();
  };

  const NextLayer = (layerName: string) => {
    breadcrumbList.value.push(layerName);
  };

  const isRootLayer = computed(() => {
    return breadcrumbList.value.length === 0 && nowLayerIndex === 0;
  });

  const CheckIsLayerDisplay = (
    nowLayerIndex: number,
    name: string
  ): boolean => {
    return (
      nowLayerIndex === breadcrumbList.value.length &&
      name === breadcrumbList.value?.[nowLayerIndex - 1]
    );
  };

  const CheckIsKeepAliveLayer = (name: string): boolean => {
    return breadcrumbList.value[nowLayerIndex] === name;
  };

  return {
    PreviousLayer,
    NextLayer,
    isRootLayer,
    CheckIsKeepAliveLayer,
    CheckIsLayerDisplay,
  };
}
