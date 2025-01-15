import React from "react";  
import { View, Text, StyleSheet } from "react-native";
import { FONTS } from "../../constants/constants";
import useResponsiveScreen from "../../hooks/useResponsiveScreen";
import HeroAnim from "./HeroAnim";

const HeroCard = ({ hero }) => {


  return (
    <View style={styles.card}>
      <HeroAnim/>
      <View style = {styles.view}>
        <Text style={[styles.name]}>{hero.name}</Text>
        <Text style={[styles.description]}>lvl: {hero.lvl}</Text>
        <Text style={[styles.description]}>power: {hero.power}</Text>
      </View>
      
    </View>
  );
};

const styles = StyleSheet.create({
  card: {
    alignItems: "center",
    justifyContent: "center",   
  },
  image: {
    resizeMode: "contain",
  },
  view: {
    alignItems: "center",
    justifyContent: "center",
    marginTop: -70,
    marginVertical: 70
  },
  name: {
    color: "#fff",
    fontFamily: FONTS.regular,
    fontSize: 15,
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
