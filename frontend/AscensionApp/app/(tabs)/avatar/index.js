import React, { useState } from 'react';
import { View, Text, StyleSheet, Pressable, ScrollView, Image } from 'react-native';
import { GestureHandlerRootView, PanGestureHandler } from 'react-native-gesture-handler';
import { COLORS } from '../../../constants/constants';

export default function HeroScreen() {
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
      position: 'left' 
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
      position: 'center' 
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
      position: 'right' 
    },
  ]);

  const rotateHeroesLeft = () => {
    setHeroes(prevHeroes => {
      const newHeroes = [...prevHeroes];
      const firstHero = newHeroes.shift();
      newHeroes.push(firstHero);
      return newHeroes.map((hero, index) => ({
        ...hero,
        position: index === 0 ? 'left' : index === 1 ? 'center' : 'right'
      }));
    });
  };

  const rotateHeroesRight = () => {
    setHeroes(prevHeroes => {
      const newHeroes = [...prevHeroes];
      const lastHero = newHeroes.pop();
      newHeroes.unshift(lastHero);
      return newHeroes.map((hero, index) => ({
        ...hero,
        position: index === 0 ? 'left' : index === 1 ? 'center' : 'right'
      }));
    });
  };

  const gestureHandler = (event) => {
    const { translationX } = event.nativeEvent;
    if (translationX < -50) {
      rotateHeroesLeft();
    } else if (translationX > 50) {
      rotateHeroesRight();
    }
  };

  const equipmentSlots = [
    { id: 'weapon', label: 'Weap', top: 100, left: 20 },
    { id: 'armor', label: 'Arm', top: 180, left: 20 },
    { id: 'helmet', label: 'Helm', top: 100, right: 20 },
    { id: 'boots', label: 'Boot', top: 260, right: 20 },
    { id: 'gloves', label: 'Glove', top: 180, right: 20 },
    { id: 'accessory', label: 'Acc', top: 260, left: 20 },
  ];

  const getHeroStyle = (position) => {
    switch (position) {
      case 'left':
        return {
          transform: [
            { scale: 0.8 },
            { translateX: -100 }
          ],
          opacity: 0.7,
          zIndex: 1
        };
      case 'right':
        return {
          transform: [
            { scale: 0.8 },
            { translateX: 100 }
          ],
          opacity: 0.7,
          zIndex: 1
        };
      default: // center
        return {
          transform: [
            { scale: 1 },
            { translateX: 0 }
          ],
          opacity: 1,
          zIndex: 2
        };
    }
  };

  const getCurrentHero = () => heroes.find(hero => hero.position === 'center');

  return (
    <View style={styles.container}>
      <View style={maxWidth=800}>
        <ScrollView style={styles.scrollView}>
          <View style={styles.topSection}>
            <View style={styles.jobSection}>
              <Text style={styles.jobText}>Profession:</Text>
              <Text style={styles.jobValue}>Warrior</Text>
            </View>
            <Pressable style={styles.equipButton}>
              <Text style={styles.equipButtonText}>Equip</Text>
            </Pressable>
          </View>

          <GestureHandlerRootView>
            <PanGestureHandler onEnded={gestureHandler}>
              <View style={styles.heroSection}>
                <View style={styles.heroesContainer}>
                  {heroes.map((hero) => (
                    <View 
                      key={hero.id} 
                      style={[
                        styles.hero,
                        getHeroStyle(hero.position)
                      ]}
                    >
                      <Image source={hero.image} style={styles.heroImage} />
                    </View>
                  ))}
                </View>

                <View style={styles.equipmentContainer}>
                  {equipmentSlots.map(slot => (
                    <Pressable
                      key={slot.id}
                      style={[
                        styles.equipmentSlot,
                        { top: slot.top, [slot.left ? 'left' : 'right']: slot.left || slot.right }
                      ]}
                    >
                      <Text style={styles.slotText}>+{'\n'}{slot.label}</Text>
                    </Pressable>
                  ))}
                </View>
              </View>
            </PanGestureHandler>
          </GestureHandlerRootView>

          <View style={styles.statsSection}>
            <View style={styles.statRow}>
              <Text style={styles.statLabel}>Power LV:</Text>
              <Text style={styles.statValue}>{getCurrentHero().powerLevel}</Text>
            </View>
            <View style={styles.statRow}>
              <Text style={styles.statLabel}>Damage:</Text>
              <Text style={styles.statValue}>{getCurrentHero().damage.toFixed(1)}</Text>
            </View>
            <View style={styles.statRow}>
              <Text style={styles.statLabel}>Class:</Text>
              <Text style={styles.statValue}>{getCurrentHero().class}</Text>
            </View>

            <View style={styles.expBar}>
              <View style={[styles.expFill, { width: `${(getCurrentHero().exp.current / getCurrentHero().exp.max) * 100}%` }]} />
              <Text style={styles.expText}>EXP: {getCurrentHero().exp.current}/{getCurrentHero().exp.max}</Text>
            </View>
            
            <View style={styles.bars}>
              <View style={styles.hpBar}>
                <Text style={styles.barText}>HP: {getCurrentHero().hp.toFixed(1)}</Text>
              </View>
              <View style={styles.mpBar}>
                <Text style={styles.barText}>MP: {getCurrentHero().mp.toFixed(1)}</Text>
              </View>
            </View>
            
          </View>
        </ScrollView>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: COLORS.energy,
  },
  scrollView: {
    alignSelf: 'center',
    width: '100%',
    maxWidth: 800,
    backgroundColor: COLORS.black,
  },
  topSection: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    padding: 15,
  },
  jobSection: {
    flexDirection: 'row',
    alignItems: 'center',
  },
  jobText: {
    color: '#fff',
    marginRight: 10,
  },
  jobValue: {
    color: '#4CAF50',
    fontWeight: 'bold',
  },
  equipButton: {
    backgroundColor: '#4CAF50',
    padding: 8,
    borderRadius: 5,
  },
  equipButtonText: {
    color: 'white',
  },
  heroSection: {
    height: 400,
    position: 'relative',
    maxWidth: 600,
    alignSelf: 'center',
    width: '100%',
  },
  heroesContainer: {
    flex: 1,
    flexDirection: 'row',
    justifyContent: 'center',
    alignItems: 'center',
    height: '100%',
  },
  hero: {
    position: 'absolute',
    width: 200,
    height: 300,
    alignItems: 'center',
    justifyContent: 'center',
  },
  heroImage: {
    width: '100%',
    height: '100%',
    resizeMode: 'contain',
  },
  equipmentContainer: {
    position: 'absolute',
    top: 0,
    left: 0,
    right: 0,
    bottom: 0,
  },
  equipmentSlot: {
    position: 'absolute',
    width: 60,
    height: 60,
    backgroundColor: '#444',
    borderRadius: 10,
    justifyContent: 'center',
    alignItems: 'center',
  },
  slotText: {
    color: '#fff',
    textAlign: 'center',
  },
  statsSection: {
    padding: 15,
  },
  statRow: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    marginBottom: 10,
  },
  statLabel: {
    color: '#fff',
  },
  statValue: {
    color: '#4CAF50',
    fontWeight: 'bold',
  },
  expBar: {
    height: 20,
    backgroundColor: '#333',
    borderRadius: 10,
    marginVertical: 10,
    overflow: 'hidden',
  },
  expFill: {
    width: '60%',
    height: '100%',
    backgroundColor: '#FFD700',
  },
  expText: {
    position: 'absolute',
    width: '100%',
    textAlign: 'center',
    color: '#000',
    fontSize: 12,
    lineHeight: 20,
  },
  bars: {
    marginTop: 15,
    gap: 10,
  },
  hpBar: {
    height: 30,
    backgroundColor: '#ff4444',
    borderRadius: 5,
    justifyContent: 'center',
    paddingLeft: 10,
  },
  mpBar: {
    height: 30,
    backgroundColor: '#4444ff',
    borderRadius: 5,
    justifyContent: 'center',
    paddingLeft: 10,
  },
  barText: {
    color: '#fff',
  },
});