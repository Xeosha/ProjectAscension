import React from "react";  
import { View, Text, StyleSheet } from "react-native";
import { FONTS } from "../../constants/constants";
import HeroAnim from "./HeroAnim";
import { useInventory } from "../../hooks/useInventory";


const HeroCard = ({ hero }) => {
  const { equipments } = useInventory();
  const heroEquipment = equipments[hero.id];


  return (
    <View style={styles.card}>
      <HeroAnim equippedItems={heroEquipment}/> 
      <View style = {styles.view}>
        <Text style={[styles.name]}>{hero.name}</Text>
        <Text style={[styles.description]}>lvl: {hero.lvl}</Text>
        <Text style={[styles.description]}>power: {hero.power}</Text>
        <Text style={[styles.description]}>hero.id: {hero.id}</Text>
      </View>
      
    </View>
  );
};

const styles = StyleSheet.create({
  card: {
    alignItems: "center",
    justifyContent: "center",   
  },
  view: {
    alignItems: "center",
    justifyContent: "center",
  },
  name: {
    color: "#fff",
    fontFamily: FONTS.regular,
    fontSize: 15,
    marginTop: -100
  },
  description: {
    fontSize: 14,
    color: "#ccc",
    fontFamily: FONTS.regular,
    paddingTop: 4,
    fontSize: 12,
  },
});

export default HeroCard;
