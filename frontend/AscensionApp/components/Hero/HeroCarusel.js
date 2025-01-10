import {
  View,
  StyleSheet,
  PanResponder,
  TouchableOpacity
} from "react-native";
import * as Animatable from "react-native-animatable";
import HeroCard from "./HeroCard";
import { Ionicons } from "@expo/vector-icons";

const HeroCarousel = ({ activeHero, setActiveHero, heroes, viewSize }) => {
  
  const nextHero = () => {
    const nextIndex = (activeHero + 1) % heroes.length;
    setActiveHero(nextIndex);
  };

  const prevHero = () => {
    const prevIndex = (activeHero - 1 + heroes.length) % heroes.length;
    setActiveHero(prevIndex);
  };

  const panResponder = PanResponder.create({
    onMoveShouldSetPanResponder: (_, gestureState) =>
      Math.abs(gestureState.dx) > Math.abs(gestureState.dy),
    onPanResponderRelease: (_, gestureState) => {
      if (gestureState.dx > 25) {
        prevHero();
      } else if (gestureState.dx < -25  ) {
        nextHero();
      }
    },
  });

  const renderHero = (hero, index) => {
    const animation = index === activeHero ? "pulse" : undefined;

    return (
      <Animatable.View
        key={hero.id}
        animation={animation}
        duration={600}
        easing="ease-out"
        style={[styles.hero, renderHeroStyle(index)]}
      >
        <HeroCard hero={hero} />
      </Animatable.View>
    );
  };

  const renderHeroStyle = (index) => {
    const isCenter = index === activeHero;
    const isLeft = (index + 1) % heroes.length === activeHero;
    const isRight = (index - 1 + heroes.length) % heroes.length === activeHero;

    let zIndex = isCenter ? 2 : 1;
    let scale = isCenter ? 1 : 0.8;
    let opacity = isCenter ? 1 : 0.5;

    let translateX = isCenter
      ? 0
      : isLeft
      ? -viewSize * 0.35
      : viewSize * 0.35;
    
    return {
      opacity,
      transform: [
        { translateX }, 
        { scale }
      ],
      zIndex,
      position: "absolute",
    };
  };

  return (
    <View style={styles.heroCarousel} {...panResponder.panHandlers}>
      <TouchableOpacity style={styles.arrowLeft} onPress={prevHero}>
        <Ionicons name="chevron-back" size={24} color="white" />
      </TouchableOpacity>

      {heroes.map((hero, index) => renderHero(hero, index))}

      <TouchableOpacity style={styles.arrowRight} onPress={nextHero}>
        <Ionicons name="chevron-forward" size={24} color="white" />
      </TouchableOpacity>
    </View>
  );
};

const styles = StyleSheet.create({
  heroCarousel: {
    width: "100%",
    height: "100%",
    alignItems: "center",
    marginTop: -35
  },
  arrowLeft: {
    position: "absolute",
    left: 20,
    top: "200%",
    zIndex: 3,
  },
  arrowRight: {
    position: "absolute",
    right: 20,
    top: "200%",
    zIndex: 3,
  },
});

export default HeroCarousel;
