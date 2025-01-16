import React from 'react';
import { View, Text, FlatList, TouchableOpacity, StyleSheet, Dimensions } from 'react-native';
import { MotiView } from 'moti';
import Ionicons from 'react-native-vector-icons/Ionicons';

const Inventory = ({ items, onClose }) => {
  return (
    <View style={styles.overlay}>
      <MotiView
        from={{ translateY: Dimensions.get('window').height, opacity: 0 }}
        animate={{ translateY: 0, opacity: 1 }}
        exit={{ translateY: Dimensions.get('window').height, opacity: 0 }}
        style={styles.inventoryContainer}
      >
        <Text style={styles.inventoryTitle}>Inventory</Text>
        <FlatList
          data={items}
          keyExtractor={(item) => item.id}
          renderItem={({ item }) => (
            <View style={styles.inventoryItem}>
              <Ionicons name={item.icon} size={36} color="#FFD700" />
              <Text style={styles.inventoryLabel}>{item.name}</Text>
              <TouchableOpacity style={styles.equipButton} onPress={() => {}}>
                <Text style={styles.equipText}>Equip</Text>
              </TouchableOpacity>
            </View>
          )}
        />
        <TouchableOpacity style={styles.closeButton} onPress={onClose}>
          <Text style={styles.closeText}>Close Inventory</Text>
        </TouchableOpacity>
      </MotiView>
    </View>
  );
};

const styles = StyleSheet.create({
  overlay: {
    position: 'absolute',
    top: 0,
    left: 0,
    right: 0,
    bottom: 0,
    justifyContent: 'center',
    alignItems: 'center',
    zIndex: 1000, // Высокий zIndex
  },
  inventoryContainer: {
    width: '90%',
    backgroundColor: 'rgba(0, 0, 0, 0.5)', // Полупрозрачный фон
    borderRadius: 20,
    padding: 20,
    maxHeight: '70%',
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 5 },
    shadowOpacity: 0.3,
    shadowRadius: 10,
    elevation: 10,
  },
  inventoryTitle: {
    fontSize: 18,
    fontWeight: 'bold',
    color: '#FFF',
    marginBottom: 10,
    textAlign: 'center',
  },
  inventoryItem: {
    flexDirection: 'row',
    alignItems: 'center',
    marginBottom: 10,
  },
  inventoryLabel: {
    flex: 1,
    fontSize: 14,
    color: '#FFF',
  },
  equipButton: {
    backgroundColor: '#FFD700',
    padding: 10,
    borderRadius: 8,
  },
  equipText: {
    fontSize: 14,
    fontWeight: 'bold',
    color: '#000',
  },
  closeButton: {
    marginTop: 20,
    backgroundColor: '#FFD700',
    padding: 10,
    borderRadius: 8,
    alignItems: 'center',
  },
  closeText: {
    fontSize: 14,
    fontWeight: 'bold',
    color: '#000',
  },
});

export default Inventory;
