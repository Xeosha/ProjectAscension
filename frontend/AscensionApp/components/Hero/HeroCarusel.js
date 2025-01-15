import React, { useState } from 'react';
import { View, TouchableOpacity, StyleSheet, Text, PanResponder } from 'react-native';
import { MotiView } from 'moti';
import HeroCard from './HeroCard'; // Импортируем ваш компонент HeroCard
import HeroCustomizationMenu from './HeroCustomizationMenu'; 

const HeroCarousel = ({ activeHero, setActiveHero, heroes, viewSize }) => {

  const [customizationVisible, setCustomizationVisible] = useState(false);

  const rotateCarousel = (direction) => {
    if (direction === 'left') {
      const nextIndex = (activeHero + 1) % heroes.length;
      setActiveHero(nextIndex);
    } else {
      const prevIndex = (activeHero - 1 + heroes.length) % heroes.length;
      setActiveHero(prevIndex);
    } 
  };

  // PanResponder for swipe gestures
  const panResponder = PanResponder.create({
    onMoveShouldSetPanResponder: (_, gestureState) =>
      Math.abs(gestureState.dx) > Math.abs(gestureState.dy),
    onPanResponderRelease: (_, gestureState) => {
      if (gestureState.dx > 25) {
        rotateCarousel('right'); // Swipe right
      } else if (gestureState.dx < -25) {
        rotateCarousel('left'); // Swipe left
      }
    },
  });

  return (
    <View style={styles.container}>
      <View style={styles.carouselContainer} {...panResponder.panHandlers}>
        {heroes.map((hero, index) => {
          const isCentered = index === activeHero;
          const isLeft = (index + 1) % heroes.length === activeHero;

          return (
            <MotiView
              key={hero.id}
              from={{
                translateX: isCentered ? 0 : isLeft ? -viewSize * 0.35 : viewSize * 0.35,
                scale: isCentered ? 1.25 : 0.8,
                opacity: isCentered ? 1 : 0.6,
              }}
              animate={{
                translateX: isCentered ? 0 : isLeft ? -viewSize * 0.35 : viewSize * 0.35,
                scale: isCentered ? 1.25 : 0.8,
                opacity: isCentered ? 1 : 0.6,
              }}
              transition={{
                type: 'spring',
                damping: 20,
                stiffness: 90,
              }}
              style={[styles.heroContainer, isCentered && styles.centeredHero]}
            >
              <TouchableOpacity
                onPress={() =>
                  setCustomizationVisible(true)
                }
              >
                <HeroCard
                  hero={hero}
                />
              </TouchableOpacity>
            </MotiView>
          );
        })}
      </View>

      <TouchableOpacity style={styles.arrowLeft} onPress={() => rotateCarousel('left')}>
        <Text style={styles.arrowText}>←</Text>
      </TouchableOpacity>
      <TouchableOpacity style={styles.arrowRight} onPress={() => rotateCarousel('right')}>
        <Text style={styles.arrowText}>→</Text>
      </TouchableOpacity>

      <HeroCustomizationMenu
        visible={customizationVisible}
        onClose={() => setCustomizationVisible(false)}
        hero={heroes[activeHero]}
      />

    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#121212',
    justifyContent: 'center',
    alignItems: 'center',
  },
  carouselContainer: {
    flexDirection: 'row',
    width: '100%',
    height: 400,
    justifyContent: 'center',
    alignItems: 'center',
    position: 'relative',
  },
  heroContainer: {
    position: 'absolute',
    alignItems: 'center',
    justifyContent: 'center',
    width: 200,
    height: 300,
  },
  centeredHero: {
    zIndex: 10,
  },
  arrowLeft: {
    position: 'absolute',
    left: -5,
    zIndex: 20,
    borderRadius: 20,
    padding: 10,
  },
  arrowRight: {
    position: 'absolute',
    right: -5,
    zIndex: 20,
    borderRadius: 20,
    padding: 10,
  },
  arrowText: {
    fontSize: 24,
    color: '#FFD700',
  },
});

export default HeroCarousel;
