import { useState, useEffect } from "react";
import { Dimensions } from "react-native";

const useResponsiveScreen = () => {
  const [dimensions, setDimensions] = useState({
    width: Dimensions.get("window").width,
    height: Dimensions.get("window").height,
    wp: (percent) => Dimensions.get("window").width * (percent / 100),
    hp: (percent) => Dimensions.get("window").height * (percent / 100),
  });

  useEffect(() => {
    const handleResize = () => {
      const { width, height } = Dimensions.get("window");
      setDimensions({
        width,
        height,
        wp: (percent) => width * (percent / 100),
        hp: (percent) => height * (percent / 100),
      });
    };

    const subscription = Dimensions.addEventListener("change", handleResize);

    return () => subscription?.remove();
  }, []);

  return dimensions;
};

export default useResponsiveScreen;
