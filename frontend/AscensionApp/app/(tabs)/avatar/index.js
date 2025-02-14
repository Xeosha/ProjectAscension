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
import { COLORS, FONTS } from "../../../constants/constants";
import HeroCarousel from "../../../components/Hero/HeroCarusel";
import JobCard from "../../../components/Hero/JobCard";
import { Emitter } from "react-native-particles";
import { useTelegramUserUnsafe  } from "../../../hooks/useTelegramScript";

const RarityBadge = ({ rarity }) => {
  const rarityColors = {
    'F': '#787878',
    'D': '#4CAF50',
    'C': '#2196F3',
    'B': '#9C27B0',
    'A': '#FF9800',
    'S': '#FF5722',
    'SS': '#E91E63',
    'SSS': '#FFD700'
  };

  return (
    <View style={[styles.rarityBadge, { backgroundColor: rarityColors[rarity] }]}>
      <Text style={styles.rarityText}>{rarity}</Text>
    </View>
  );
};


const HeroScreen = () => {
  const { wp, width, height } = useResponsiveScreen();

  const [margin, setMargin] = useState(1);
  const [viewSize, setViewSize] = useState(1);

  const [activeHero, setActiveHero] = useState(0);

  const user = useTelegramUserUnsafe();
  console.log(user.userName);

  useEffect(() => {
    const newMargin = wp(32) > 400 ? wp(32) : 15;
    setMargin(newMargin);
    setViewSize(wp(100) - 2 * newMargin);
  }, [wp]); 

  const [heroes, setHeroes] = useState( [
    { id: "hero1", name: "Aragorn", profession: "Warrior", 
      lvl: 17, power: 1000, rarity: "SSS", exp: 2500,
      maxExp: 3000, attack: 750, agility: 320, critRate: 15, defense: 10, health: 10,
      biography: "A legendary warrior from the shadow realm, sworn to protect the balance between light and darkness.",
      abilities: [
        {
          name: "Shadow Strike",
          description: "Deals massive damage from the shadows",
          icon: "flash-outline"
        },
        {
          name: "Dark Shield",
          description: "Creates a protective barrier of darkness",
          icon: "shield-outline"
        }
      ]
    }, 
    { id: "hero2", name: "Legolas", profession: "Archer", lvl: 18, power: 200,
      rarity: "B", exp: 2500,
      maxExp: 3000, attack: 750, agility: 320, critRate: 15, defense: 10, health: 10,
      biography: "A legendary warrior from the shadow realm, sworn to protect the balance between light and darkness.",
      abilities: [
        {
          name: "Shadow Strike",
          description: "Deals massive damage from the shadows",
          icon: "flash-outline"
        },
        {
          name: "Dark Shield",
          description: "Creates a protective barrier of darkness",
          icon: "shield-outline"
        }
      ]
    },
    { id: "hero3", name: "Gandalf", profession: "Wizard", lvl: 19, power: "20k",
      rarity: "C", exp: 2500,
      maxExp: 3000, attack: 750, agility: 320, critRate: 15, defense: 10, health: 10,
      biography: "A legendary warrior from the shadow realm, sworn to protect the balance between light and darkness.",
      abilities: [
        {
          name: "Shadow Strike",
          description: "Deals massive damage from the shadows",
          icon: "flash-outline"
        },
        {
          name: "Dark Shield",
          description: "Creates a protective barrier of darkness",
          icon: "shield-outline"
        }
      ]


    },
  ]);

  const currentHero = heroes[activeHero];


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

      <ScrollView 
        style={[, {marginHorizontal:margin}]} 
        showsVerticalScrollIndicator={false}
        contentContainerStyle={{ paddingBottom: 120 }}
      >
        <Text style={styles.title}>{user.userName}</Text>
        <Text style={styles.title}>Xeosha</Text>
        <JobCard hero={currentHero} />
        <HeroCarousel heroes={heroes} viewSize={viewSize} activeHero={activeHero} setActiveHero={setActiveHero}/>   

        <RarityBadge rarity={currentHero.rarity} />
        
        <View style={styles.card}>
          <Text style={styles.statLabel}>Experience:</Text>
          <View style={styles.statBarBg}>
            <View
              style={[
                styles.statBarFill,
                { width: `${(currentHero.exp / currentHero.maxExp) * 100}%` },
              ]}
            />
          </View>
          <Text style={styles.statValue}>
            {currentHero.exp}/{currentHero.maxExp}
          </Text>
        </View>

        {/* Biography */}
        <View style={styles.card}>
          <Text style={styles.cardTitle}>Biography</Text>
          <Text style={styles.cardText}>{currentHero.biography}</Text>
        </View>

        {/* Combat Stats */}
        <View style={styles.card}>
          <Text style={styles.cardTitle}>Combat Stats</Text>
          <Text style={styles.cardText}>Health: {currentHero.health}</Text>
          <Text style={styles.cardText}>Power: {currentHero.power}</Text>
          <Text style={styles.cardText}>Attack: {currentHero.attack}</Text>
          <Text style={styles.cardText}>Defense: {currentHero.defense}</Text>
          <Text style={styles.cardText}>Agility: {currentHero.agility}</Text>
          <Text style={styles.cardText}>Critical Rate: {currentHero.critRate}%</Text>
        </View>

        {/* Abilities */}
        <View style={styles.card}>
          <Text style={styles.cardTitle}>Abilities</Text>
          {currentHero.abilities.map((ability, index) => (
            <View key={index} style={styles.abilityContainer}>
              <Text style={styles.abilityName}>{ability.name}</Text>
              <Text style={styles.abilityDescription}>{ability.description}</Text>
            </View>
          ))}
        </View>
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
  rarityBadge: {
    alignSelf: "center",
    paddingHorizontal: 16,
    paddingVertical: 4,
    borderRadius: 8,
    marginTop: 8,
    marginBottom: 2,
  },
  rarityText: {
    fontSize: 16,
    fontWeight: "bold",
    color: "#fff",
    fontFamily: FONTS.regular,
  },
  statBarContainer: {
    marginVertical: 8,
    marginHorizontal: 16,
  },
  statLabel: {
    fontSize: 16,
    color: "#fff",
    marginBottom: 4,
    fontFamily: FONTS.regular,
    color: "#FFD700",
  },
  statBarBg: {
    height: 8,
    backgroundColor: "#444",
    borderRadius: 4,
    overflow: "hidden",
  },
  statBarFill: {
    height: "100%",
    backgroundColor: COLORS.primary,
  },
  statValue: {
    fontSize: 14,
    color: "#fff",
    marginTop: 4,
    fontFamily: FONTS.regular,
    color: "#FFD700",
  },
  card: {
    backgroundColor: "#333",
    margin: 8,
    padding: 16,
    borderRadius: 8,
  },
  cardTitle: {
    fontSize: 16,
    fontWeight: "bold",
    color: "#fff",
    marginBottom: 8,
    fontFamily: FONTS.regular,
    color: "#FFD700",
  },
  cardText: {
    fontSize: 12,
    color: "#ccc",
    marginBottom: 4,
    fontFamily: FONTS.regular,
  },
  abilityContainer: {
    marginTop: 8,
  },
  abilityName: {
    fontSize: 14,
    fontWeight: "bold",
    color: COLORS.primary,
    fontFamily: FONTS.regular,
    marginBottom: 10,
    
  },
  abilityDescription: {
    fontSize: 12,
    color: "#ccc",
    fontFamily: FONTS.regular,
  },
});
