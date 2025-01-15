import { View, Image, StyleSheet } from "react-native";
import { IMAGES } from '../../constants/constants';

const HeroAnim = () => {
  return (
    <View style={styles.container}>
      {/* Базовая анимация персонажа */}
      <Image source={IMAGES.heroAnim} style={styles.baseImage} />
      {/* Оружие поверх персонажа */}
      <Image source={IMAGES.heroWeapon} style={styles.overlayImage} />
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
