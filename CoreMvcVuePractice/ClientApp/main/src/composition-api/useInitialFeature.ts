import { onBeforeMount, reactive, getCurrentInstance, onUnmounted } from "vue";
import emitter from "@/tools/Emitter";

export default function (originalData: any) {
  const instance = getCurrentInstance();

  onBeforeMount(() => {
    if (instance?.type.name) {
      emitter.on(instance.type.name, () => {
        InitialData();
      });
    }
  });

  onUnmounted(() => {
    if (instance?.type.name) {
      emitter.off(instance.type.name, () => {
        InitialData();
      });
    }
  });

  const GenerateData = () => {
    return JSON.parse(JSON.stringify(originalData));
  };

  const data = reactive(GenerateData());

  const InitialData = () => {
    Object.assign(data, GenerateData());
  };

  return { data };
}
