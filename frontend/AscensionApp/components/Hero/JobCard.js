import {
  View,
  Text,
  StyleSheet,
  Pressable,
} from 'react-native';

import {
  COLOR,
  FONTS
} from '../../constants/constants'

const JobCard = ({ hero }) => {
  return (
    <View style={styles.topSection}>
      <Text style={styles.jobText}>Profession: {hero?.profession || "Unknown"}</Text>
      <Pressable style={styles.equipButton} onPress={() => console.log(`Equipped ${hero?.name}`)}>
        <Text style={styles.equipButtonText}>Equip</Text>
      </Pressable>
    </View>
  );
};

export default JobCard;

const styles = StyleSheet.create({
  topSection: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    backgroundColor: '#222',
    padding: 10,
    borderRadius: 8,
    marginVertical: 8,
  },
  jobText: { 
    color: '#fff', 
    fontSize: 12, 
    fontFamily: FONTS.regular,
  },
  equipButton: {
    backgroundColor: '#4CAF50',
    padding: 8,
    borderRadius: 5,
    marginLeft: 8,
  },
  equipButtonText: { 
    fontFamily: FONTS.regular,
    color: 'white', 
    fontSize: 10,
  },
});
