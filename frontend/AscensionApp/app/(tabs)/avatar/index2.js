import React, { useState } from 'react';
import {
  View,
  Text,
  StyleSheet,
  Pressable,
  ScrollView,
  Image,
} from 'react-native';
import { GestureHandlerRootView, PanGestureHandler } from 'react-native-gesture-handler';
import { COLORS } from '../../../constants/constants';

const HeroCard = ({ hero, style }) => (
  <View style={[styles.heroSection, style]}>
    <Image source={hero.image} style={styles.heroImage} />
  </View>
);

const EquipmentSlot = ({ slot }) => (
  <Pressable
    key={slot.id}
    style={[
      styles.equipmentSlot,
      { top: slot.top, [slot.left ? 'left' : 'right']: slot.left || slot.right },
    ]}
  >
    <Text style={styles.slotText}>+{'\n'}{slot.label}</Text>
  </Pressable>
);

const HeroScreen = () => {
  const [heroes, setHeroes] = useState([
    {
      id: 0,
      name: "Hero 1",
      level: 15,
      hp: 150,
      mp: 15,
      powerLevel: 750,
      damage: 65.5,
      class: 'E',
      exp: { current: 1250, max: 2000 },
      image: require('./hero1.png'),
      position: 'left',
    },
    {
      id: 1,
      name: "Hero 2",
      level: 17,
      hp: 170,
      mp: 17,
      powerLevel: 860,
      damage: 75.0,
      class: 'D',
      exp: { current: 1800, max: 2500 },
      image: require('./hero2.png'),
      position: 'center',
    },
    {
      id: 2,
      name: "Hero 3",
      level: 12,
      hp: 120,
      mp: 12,
      powerLevel: 650,
      damage: 55.5,
      class: 'F',
      exp: { current: 800, max: 1500 },
      image: require('./hero3.png'),
      position: 'right',
    },
  ]);

  const equipmentSlots = [
    { id: 'weapon', label: 'Weap', top: 100, left: 20 },
    { id: 'armor', label: 'Arm', top: 180, left: 20 },
    { id: 'helmet', label: 'Helm', top: 100, right: 20 },
    { id: 'boots', label: 'Boot', top: 260, right: 20 },
    { id: 'gloves', label: 'Glove', top: 180, right: 20 },
    { id: 'accessory', label: 'Acc', top: 260, left: 20 },
  ];

  const rotateHeroes = (direction) => {
    setHeroes((prevHeroes) => {
      const newHeroes = [...prevHeroes];
      if (direction === 'left') {
        const firstHero = newHeroes.shift();
        newHeroes.push(firstHero);
      } else {
        const lastHero = newHeroes.pop();
        newHeroes.unshift(lastHero);
      }
      return newHeroes.map((hero, index) => ({
        ...hero,
        position: index === 0 ? 'left' : index === 1 ? 'center' : 'right',
      }));
    });
  };

  const gestureHandler = (event) => {
    const { translationX } = event.nativeEvent;
    if (translationX < -50) {
      rotateHeroes('left');
    } else if (translationX > 50) {
      rotateHeroes('right');
    }
  };

  const getHeroStyle = (position) => ({
    ...styles.heroBase,
    ...{
      left: position === 'left' ? -100 : position === 'right' ? 100 : 0,
      zIndex: position === 'center' ? 2 : 1,
      opacity: position === 'center' ? 1 : 0.7,
      transform: [{ scale: position === 'center' ? 1 : 0.8 }],
    },
  });

  const getCurrentHero = () => heroes.find((hero) => hero.position === 'center') || heroes[0];

  const currentHero = getCurrentHero();

  
  return (
    <View style={styles.container}>
      <ScrollView contentContainerStyle={styles.scrollView} >
        <View style={styles.topSection}>
          <Text style={styles.jobText}>Profession: Warrior</Text>
          <Pressable style={styles.equipButton}>
            <Text style={styles.equipButtonText}>Equip</Text>
          </Pressable>
        </View>

        <GestureHandlerRootView>
          <PanGestureHandler onEnded={gestureHandler}>
            <View style={styles.heroSection}>
              {heroes.map((hero) => (
                <HeroCard key={hero.id} hero={hero} style={getHeroStyle(hero.position)} />
              ))}
              <View style={styles.equipmentContainer}>
                {equipmentSlots.map((slot) => (
                  <EquipmentSlot key={slot.id} slot={slot} />
                ))}
              </View>
            </View>
          </PanGestureHandler>
        </GestureHandlerRootView>

        <View style={styles.statsSection}>
          <View style={styles.statRow}>
            <Text style={styles.statLabel}>Power LV:</Text>
            <Text style={styles.statValue}>{currentHero.powerLevel}</Text>
          </View>
          <View style={styles.statRow}>
            <Text style={styles.statLabel}>Damage:</Text>
            <Text style={styles.statValue}>{currentHero.damage.toFixed(1)}</Text>
          </View>
          <View style={styles.statRow}>
            <Text style={styles.statLabel}>Class:</Text>
            <Text style={styles.statValue}>{currentHero.class}</Text>
          </View>
          <View style={styles.expBar}>
            <View
              style={[
                styles.expFill,
                { width: `${(currentHero.exp.current / currentHero.exp.max) * 100}%` },
              ]}
            />
            <Text style={styles.expText}>
              EXP: {currentHero.exp.current}/{currentHero.exp.max}
            </Text>
          </View>

          
        </View>
      </ScrollView>
    </View>
  );
};

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: COLORS.black },
  scrollView: { padding: 15 },
  topSection: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
  },
  jobText: { color: '#fff', fontSize: 16 },
  equipButton: {
    backgroundColor: '#4CAF50',
    padding: 8,
    borderRadius: 5,
  },
  equipButtonText: { color: 'white', fontWeight: 'bold' },
  heroSection: { height: 400, alignItems: 'center', justifyContent: 'center' },
  heroBase: { position: 'absolute', width: 200, height: 300 },
  heroImage: { width: '100%', height: '100%', resizeMode: 'contain' },
  equipmentContainer: { position: 'absolute', width: '100%', height: '100%' },
  equipmentSlot: {
    position: 'absolute',
    width: 60,
    height: 60,
    backgroundColor: '#444',
    borderRadius: 10,
    justifyContent: 'center',
    alignItems: 'center',
  },
  slotText: { color: '#fff', textAlign: 'center', fontSize: 12 },
  statsSection: { marginTop: 20 },
  statRow: { flexDirection: 'row', justifyContent: 'space-between', marginBottom: 10 },
  statLabel: { color: '#fff', fontSize: 16 },
  statValue: { color: '#4CAF50', fontWeight: 'bold', fontSize: 16 },
  expBar: { height: 20, backgroundColor: '#333', borderRadius: 10, marginVertical: 10 },
  expFill: { height: '100%', backgroundColor: '#FFD700' },
  expText: { position: 'absolute', textAlign: 'center', color: '#fff', fontSize: 12 },
});

export default HeroScreen;
