import React from 'react';
import { View, Text, FlatList, TouchableOpacity, StyleSheet, Dimensions } from 'react-native';
import { MotiView } from 'moti';
import Ionicons from 'react-native-vector-icons/Ionicons';

const { width, height } = Dimensions.get('window');

const InventoryItem = ({ item, onSelect, index }) => (
  <MotiView
    from={{ opacity: 0, translateY: 20 }}
    animate={{ opacity: 1, translateY: 0 }}
    transition={{ delay: index * 50 }}
  >
    <TouchableOpacity
      style={[
        styles.itemContainer,
        item.equippedBy && styles.itemEquipped
      ]}
      onPress={() => onSelect(item.id)}
      disabled={item.equippedBy}
    >
      <Ionicons name={item.icon} size={24} color="#FFD700" />
      <View style={styles.itemContent}>
        <Text style={styles.itemName}>{item.name}</Text>
        <Text style={styles.itemPower}>Power: {item.power}</Text>
      </View>
      {item.equippedBy && (
        <Ionicons name="checkmark-circle" size={24} color="#4CAF50" />
      )}
    </TouchableOpacity>
  </MotiView>
);

const HeroInventory = ({ items, title, onItemSelect, onUnequip, onClose }) => {
  return (
    <View style={styles.overlay}>
      <MotiView
        from={{ opacity: 0, scale: 0.9 }}
        animate={{ opacity: 1, scale: 1 }}
        exit={{ opacity: 0, scale: 0.9 }}
        style={styles.modalContainer}
      >
        <View style={styles.header}>
          <Text style={styles.title}>{title}</Text>
          <TouchableOpacity onPress={onClose}>
            <Ionicons name="close" size={24} color="#FFD700" />
          </TouchableOpacity>
        </View>

        <View style={styles.listContainer}>
          <FlatList
            data={items}
            renderItem={({ item, index }) => (
              <InventoryItem
                item={item}
                onSelect={onItemSelect}
                index={index}
              />
            )}
            keyExtractor={item => item.id}
            ListEmptyComponent={
              <Text style={styles.emptyText}>No items available</Text>
            }
          />
        </View>

        <TouchableOpacity 
          style={styles.unequipButton} 
          onPress={onUnequip}
        >
          <Ionicons name="remove-circle-outline" size={20} color="#FFD700" />
          <Text style={styles.unequipText}>Unequip</Text>
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
    zIndex: 24,
  },
  modalContainer: {
    width: width * 0.8, // 80% от ширины экрана
    maxHeight: height * 0.7, // 70% от высоты экрана
    backgroundColor: '#333',
    borderRadius: 10,
    padding: 16,
    width: 450,
    backgroundColor: 'rgba(0, 0, 0, 0.2)',
  },
  header: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    marginBottom: 16,
  },
  title: {
    fontSize: 18,
    color: '#FFD700',
    fontWeight: 'bold',
    textTransform: 'capitalize',
  },
  listContainer: {
    maxHeight: height * 0.5, // 50% от высоты экрана
  },
  itemContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    backgroundColor: '#444',
    padding: 12,
    marginBottom: 8,
    borderRadius: 8,
  },
  itemEquipped: {
    backgroundColor: '#555',
  },
  itemContent: {
    flex: 1,
    marginLeft: 12,
  },
  itemName: {
    color: '#fff',
    fontSize: 16,
  },
  itemPower: {
    color: '#aaa',
    fontSize: 14,
  },
  emptyText: {
    color: '#aaa',
    textAlign: 'center',
    padding: 16,
  },
  unequipButton: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'center',
    backgroundColor: '#333',
    padding: 12,
    borderRadius: 8,
    marginTop: 16,
    borderWidth: 1,
    borderColor: '#FFD700',
  },
  unequipText: {
    color: '#FFD700',
    fontSize: 16,
    marginLeft: 8,
  }
});

export default HeroInventory;