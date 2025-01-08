import {
  View,
  Text,
  StyleSheet,
  Pressable,
  ScrollView,
  Image,
  SafeAreaView,
} from "react-native";

import { 
  widthPercentageToDP as wp,
  heightPercentageToDP as hp 
} from 'react-native-responsive-screen';


import { COLORS, FONTS } from "../../../constants/constants"
import JobCard from "../../../components/Hero/JobCard";

const HeroScreen = () => {
  // Пример данных о героях
  const heroes = [
    { id: 1, name: "Aragorn", profession: "Warrior", image: "https://via.placeholder.com/150" },
    { id: 2, name: "Legolas", profession: "Archer", image: "https://via.placeholder.com/150" },
    { id: 3, name: "Gandalf", profession: "Wizard", image: "https://via.placeholder.com/150" },
  ];

  return (
    <SafeAreaView style={styles.safeContainer}>
      <View style={styles.container}>
        <Text style={styles.title}>Xeosha</Text>
        <ScrollView contentContainerStyle={styles.scrollContainer}>
          <JobCard hero={heroes[0]} />
        </ScrollView>
      
      </View>
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
    marginHorizontal: wp('35%') > 300 ? wp('35%') : 15,
  },
  title: {
    fontSize: 24,
    fontWeight: "bold",
    color: "#fff",
    marginTop: 24,
    marginBottom: 16,
    textAlign: "center",
    fontFamily: FONTS.regular,
  },
  scrollContainer: {
    paddingBottom: 16,
  },
});
