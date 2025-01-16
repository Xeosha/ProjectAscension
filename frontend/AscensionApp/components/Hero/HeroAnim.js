import { View, Image, StyleSheet } from "react-native";

const HeroAnim = ( { equippedItems } ) => {
  return (
    <View style={styles.container}>
      {equippedItems.baseImage && (
        <Image source={equippedItems.baseImage} style={styles.overlayImage} />
      )}
      {equippedItems.weapon && (
        <Image source={equippedItems.weapon} style={styles.overlayImage} />
      )}
    </View>
  );
};

export default HeroAnim;

const styles = StyleSheet.create({
  container: {
    justifyContent: "center",
    alignItems: "center",
    width: 350,
    height: 350, // Размер контейнера под изображения
    position: "relative", // Для наложения дочерних элементов
    marginLeft: -50,
  },
  baseImage: {
    width: 350,
    height: 350,
    position: "absolute", // Абсолютное позиционирование
  },  
  overlayImage: {
    width: 350,
    height: 350,
    position: "absolute", // Абсолютное позиционирование
    zIndex: 1, // Указывает, что это изображение находится поверх
  },
});
