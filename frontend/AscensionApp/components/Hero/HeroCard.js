import React from "react";
import { View, Text, Image, StyleSheet } from "react-native";
import { FONTS } from "../../constants/constants";
import useResponsiveScreen from "../../hooks/useResponsiveScreen";

const HeroCard = ({ hero }) => {
  const { wp, hp } = useResponsiveScreen();

  return (
    <View style={styles.card}>
      <Image
        source={hero.image}
        style={[styles.image, { width: wp(90), height: hp(50) }]}
      />
      <View style = {styles.view}>
        <Text style={[styles.name, { fontSize: hp(2) } ]}>{hero.name}</Text>
        <Text style={styles.description}>lvl: {hero.lvl}</Text>
        <Text style={styles.description}>power: {hero.power}</Text>
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
    marginTop: -45,
  },
  name: {
    color: "#fff",
    fontFamily: FONTS.regular,
  },
  description: {
    fontSize: 14,
    color: "#ccc",
    fontFamily: FONTS.regular,
    paddingTop: 4,
  },
});

export default HeroCard;
