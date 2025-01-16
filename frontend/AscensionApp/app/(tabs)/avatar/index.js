import React, { useState, useEffect } from "react";
import {
  View,
  Text,
  StyleSheet,
  ScrollView,
  SafeAreaView,
} from "react-native";
import { LinearGradient } from "expo-linear-gradient"; // Импортируем LinearGradient из expo-linear-gradient
import useResponsiveScreen from "../../../hooks/useResponsiveScreen";
import { COLORS, FONTS, IMAGES } from "../../../constants/constants";
import HeroCarousel from "../../../components/Hero/HeroCarusel";
import JobCard from "../../../components/Hero/JobCard";
import { Emitter } from "react-native-particles";


const HeroScreen = () => {
  const { wp, width, height } = useResponsiveScreen();

  const [margin, setMargin] = useState(1);
  const [viewSize, setViewSize] = useState(1);

  const [activeHero, setActiveHero] = useState(0);

  useEffect(() => {
    const newMargin = wp(32) > 400 ? wp(32) : 15;
    setMargin(newMargin);
    setViewSize(wp(100) - 2 * newMargin);
  }, [wp]); 

  const [heroes, setHeroes] = useState( [
    { id: "hero1", name: "Aragorn", profession: "Warrior", image: IMAGES.hero, lvl: 17, power: 1000 },
    { id: "hero2", name: "Legolas", profession: "Archer", image: IMAGES.hero, lvl: 18, power: 200 },
    { id: "hero3", name: "Gandalf", profession: "Wizard", image: IMAGES.hero, lvl: 19, power: "20k" },
  ]);


  return (
    <SafeAreaView style={styles.safeContainer}>

      <Emitter
        numberOfParticles={10}
        emissionRate={1 }
        interval={1}
        particleLife={4500}
        direction={360}
        spread={360}
        speed={100} 
        gravity={2}
        fromPosition={() => ({ x: Math.random() * width, y: Math.random() * height })}
        infiniteLoop={true}
        style={styles.emitter}
      >
        <Text style={styles.snowflake}>✨</Text>
      </Emitter>

      <LinearGradient
        colors={["transparent", COLORS.primary, "transparent"]}
        style={[styles.gradientOverlay, { pointerEvents: 'none' }]} // Применение pointerEvents: 'none'
        start={{ x: 0.5, y: 0 }}
        end={{ x: 0.5, y: 1 }}
      />

      <ScrollView style={[, {marginHorizontal:margin}]}>
        <Text style={styles.title}>Xeosha</Text>
        <JobCard hero={heroes[activeHero]} />
        <HeroCarousel heroes={heroes} viewSize={viewSize} activeHero={activeHero} setActiveHero={setActiveHero}/>   
      </ScrollView>

    </SafeAreaView>
  );
};

export default HeroScreen;

const styles = StyleSheet.create({
  safeContainer: {
    flex: 1,
    backgroundColor: COLORS.background,
  },
  container: {
    flex: 1,
    position: "relative", // Для позиционирования свечения
  },
  title: {
    fontSize: 24,
    color: "#fff",
    marginTop: 24,
    marginBottom: 16,
    textAlign: "center",
    fontFamily: FONTS.regular,
  },
  scrollContainer: {
    paddingBottom: 16,
  },
  gradientOverlay: {
    position: "absolute",
    top: "40%", // Позиция свечения в центре карусели
    left: 0,
    right: 0,
    height: 1000,
    zIndex: 2, // Размещение над содержимым
  },
  snowflake: { fontSize: 20, color: "white" },
  emitter: { position: "absolute", width: "100%", height: "100%" },
});
