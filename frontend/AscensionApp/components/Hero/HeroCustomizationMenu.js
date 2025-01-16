import React, {useState} from 'react';
import { View, StyleSheet, TouchableOpacity, Text } from 'react-native';
import { MotiView } from 'moti';
import Ionicons from 'react-native-vector-icons/Ionicons';
import HeroInventory from "./HeroInventory"
import { IMAGES } from "../../constants/constants"

const HeroCustomizationMenu = ({ visible, onClose, hero }) => {
  if (!visible)
    return null;

  const [selectedCategory, setSelectedCategory] = useState(null);

  const customizationItems = [
    { id: 'sword', label: 'Sword', icon: 'shield-outline' },
    { id: 'helm', label: 'Helmet', icon: 'headset-outline' },
    { id: 'chest', label: 'Chest', icon: 'shirt-outline' },
    { id: 'legs', label: 'Legs', icon: 'walk-outline' },
    { id: 'boots', label: 'Boots', icon: 'footsteps-outline' },
    { id: 'glove', label: 'Gloves', icon: 'hand-right-outline' },
  ];

  const inventory = [
    { id: '1', name: 'Steel Sword', category: 'sword', icon: 'shield', image: IMAGES.heroWeapo, isEquipped: false},
    { id: '2', name: 'Iron Helm', category: 'helm', icon: 'headset', image: IMAGES.heroWeapo, isEquipped: false },
    { id: '3', name: 'Leather Chestplate', category: 'chest', icon: 'shirt', image: IMAGES.heroWeapo, isEquipped: false },
    { id: '4', name: 'Steel Leggings', category: 'legs', icon: 'walk', image: IMAGES.heroWeapo, isEquipped: false },
    { id: '5', name: 'Swift Boots', category: 'boots', icon: 'footsteps', image: IMAGES.heroWeapo, isEquipped: false },
    { id: '6', name: 'Battle Gloves', category: 'glove', icon: 'hand-right', image: IMAGES.heroWeapo, isEquipped: false },
  ];

  const filteredInventory = inventory.filter(item => item.category === selectedCategory);


  return (
    <MotiView
      from={{ opacity: 0 }}
      animate={{ opacity: 1 }}
      exit={{ opacity: 0 }}
      style={styles.menuContainer}
    >
      <View style={styles.leftColumn}>
        {customizationItems.slice(0, 3).map((item, index) => (
          <MotiView
            key={item.id}
            from={{ translateX: -50, opacity: 0 }}
            animate={{ translateX: 0, opacity: 1 }}
            transition={{ delay: index * 50, type: 'timing', duration: 300 }}
            style={styles.iconContainer}
          >
            <TouchableOpacity
              style={styles.iconButton}
              onPress={() => setSelectedCategory(item.id)}
            >
              <Ionicons name={item.icon} size={36} color="#FFD700" />
              <Text style={styles.iconLabel}>{item.label}</Text>
            </TouchableOpacity>
          </MotiView>
        ))}
      </View>
      <View style={styles.rightColumn}>
        {customizationItems.slice(3).map((item, index) => (
          <MotiView
            key={item.id}
            from={{ translateX: 50, opacity: 0 }}
            animate={{ translateX: 0, opacity: 1 }}
            transition={{ delay: index * 50, type: 'timing', duration: 300 }}
            style={styles.iconContainer}
          >
            <TouchableOpacity
              style={styles.iconButton}
              onPress={() => setSelectedCategory(item.id)}
            >
              <Ionicons name={item.icon} size={36} color="#FFD700" />
              <Text style={styles.iconLabel}>{item.label}</Text>
            </TouchableOpacity>
          </MotiView>
        ))}
      </View>

      {selectedCategory && (
        <HeroInventory
          items={filteredInventory}
          onClose={() => setSelectedCategory(null)}
        />
      )}
      
      <TouchableOpacity style={styles.closeButton} onPress={onClose}>
        <Text style={styles.closeText}>Close</Text>
      </TouchableOpacity>
    </MotiView>
  );
};

const styles = StyleSheet.create({
  menuContainer: {
    position: 'absolute',
    top: 0,
    left: 0,
    right: 0,
    bottom: 0,
    backgroundColor: 'rgba(0, 0, 0, 0.7)',
    justifyContent: 'center',
    alignItems: 'center',
  },
  leftColumn: {
    position: 'absolute',
    left: 30,
    top: '20%',
    justifyContent: 'space-evenly',
    alignItems: 'center',
    height: '60%',
  },
  rightColumn: {
    position: 'absolute',
    right: 30,
    top: '20%',
    justifyContent: 'space-evenly',
    alignItems: 'center',
    height: '60%',
  },
  iconContainer: {
    alignItems: 'center',
  },
  iconButton: {
    width: 70,
    height: 70,
    backgroundColor: '#444',
    borderRadius: 35,
    justifyContent: 'center',
    alignItems: 'center',
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 5 },
    shadowOpacity: 0.3,
    shadowRadius: 10,
    elevation: 5,
  },
  iconLabel: {
    fontSize: 12,
    color: '#FFF',
    textAlign: 'center',
    marginTop: 8,
  },
  closeButton: {
    position: 'absolute',
    bottom: 50,
    backgroundColor: '#FFD700',
    paddingVertical: 10,
    paddingHorizontal: 20,
    borderRadius: 15,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 5 },
    shadowOpacity: 0.3,
    shadowRadius: 10,
    elevation: 5,
  },
  closeText: {
    fontSize: 16,
    fontWeight: 'bold',
    color: '#000',
    textAlign: 'center',
  },
});

export default HeroCustomizationMenu;
