meta:
  id: terraria_player
  file-extension: plr
  endian: le
  bit-endian: be
  imports:
    - vlq_base128_le
doc: |
  The format for Terraria player files. This format has only been tested on
  Terraria 1.4 (version 234). Note that you must decrypt the file first before
  reading it; Terraria uses C#'s RijndaelManaged encrpytion system, with no
  padding, using the string "h3y_gUyZ" as both the key and the IV.
types:
  csharp_string:
    seq:
      - id: length
        type: vlq_base128_le
      - id: contents
        type: str
        size: length.value
        encoding: UTF-8
  color:
    seq:
      - id: r
        type: u1
      - id: g
        type: u1
      - id: b
        type: u1
  equipment_slot:
    seq:
      - id: id
        type: s4
      - id: prefix
        type: u1
  container_slot:
    seq:
      - id: id
        type: s4
      - id: stack
        type: s4
      - id: prefix
        type: u1
  inventory_slot:
    seq:
      - id: id
        type: s4
      - id: stack
        type: s4
      - id: prefix
        type: u1
      - id: favorited
        type: u1
  buff:
    seq:
      - id: type
        type: s4
      - id: time
        type: s4
  dummy: {}
  sp_body:
    seq:
      - id: "y"
        type: s4
      - id: "i"
        type: s4
      - id: "n"
        type: csharp_string
  sp:
    seq:
      - id: x
        type: s4
      - id: rest
        type:
          switch-on: x
          cases:
            -1: dummy
            _: sp_body
  research:
    seq:
      - id: item
        type: csharp_string
      - id: count
        type: s4
  # creative_power_value:
  #   seq:
  #     - id: key
  #       type: u2
  #     - id: data
  #       type: dummy
  #       doc: TODO
  # creative_power:
  #   seq:
  #     - id: has_more
  #       type: u1
  #     - id: value
  #       type: creative_power_value
  #       if: has_more != 0
seq:
  - id: version
    type: s4
  - id: type
    type: u8
  - id: revision
    type: u4
  - id: favorited
    type: u8
  - id: name
    type: csharp_string
  - id: difficulty
    type: u1
  - id: playtime
    type: s8
  - id: hair
    type: s4
  - id: hair_dye
    type: u1
  - id: hide_accessories
    type: b1
    repeat: expr
    repeat-expr: 16
    doc: Only 10 bits are currently used here.
  - id: hide_misc
    type: b1
    repeat: expr
    repeat-expr: 8
  - id: skin_variant
    type: u1
  - id: life
    type: s4
  - id: max_life
    type: s4
  - id: mana
    type: s4
  - id: max_mana
    type: s4
  - id: has_extra_accessory_slot
    type: u1
  - id: unlocked_biome_torches
    type: u1
  - id: using_biome_torches
    type: u1
  - id: downed_dd2_event
    type: u1
  - id: tax_money
    type: s4
  - id: hair_color
    type: color
  - id: skin_color
    type: color
  - id: eye_color
    type: color
  - id: shirt_color
    type: color
  - id: undershirt_color
    type: color
  - id: pants_color
    type: color
  - id: shoe_color
    type: color
  - id: armor
    type: equipment_slot
    repeat: expr
    repeat-expr: 20
  - id: dyes
    type: equipment_slot
    repeat: expr
    repeat-expr: 10
  - id: inventory
    type: inventory_slot
    repeat: expr
    repeat-expr: 58
  - id: misc_equips_and_dyes
    type: equipment_slot
    repeat: expr
    repeat-expr: 5 * 2
  - id: bank
    type: container_slot
    repeat: expr
    repeat-expr: 40
  - id: bank2
    type: container_slot
    repeat: expr
    repeat-expr: 40
  - id: bank3
    type: container_slot
    repeat: expr
    repeat-expr: 40
  - id: bank4
    type: container_slot
    repeat: expr
    repeat-expr: 40
  - id: void_vault_info
    type: b1
    repeat: expr
    repeat-expr: 8
  - id: buffs
    type: buff
    repeat: expr
    repeat-expr: 22
  - id: sps
    type: sp
    repeat: until
    repeat-until: _.x == -1
  - id: hb_locked
    type: u1
  - id: hide_info
    type: u1
    repeat: expr
    repeat-expr: 13
  - id: angler_quests_finished
    type: s4
  - id: dpad_radial_bindings
    type: s4
    repeat: expr
    repeat-expr: 4
  - id: builder_acc_status
    type: s4
    repeat: expr
    repeat-expr: 12
  - id: bartender_quest_log
    type: s4
  - id: dead
    type: u1
  - id: respawn_timer
    type: s4
    if: dead != 0
  - id: datetime_saved
    type: s8
  - id: golf_score
    type: s4
  - id: n_researches_completed
    type: s4
  - id: researches_completed
    type: research
    repeat: expr
    repeat-expr: n_researches_completed
  - id: temp_items
    type: b1
    repeat: expr
    repeat-expr: 4
  - id: temp_item_mouse
    type: container_slot
    if: temp_items[0]
  - id: temp_item_by_index
    type: container_slot
    if: temp_items[1]
  - id: temp_item_guide
    type: container_slot
    if: temp_items[2]
  - id: temp_item_reforge
    type: container_slot
    if: temp_items[3]
  - id: creative_powers
    # type: creative_power
    # repeat: until
    # repeat-until: "!_.has_more"
    size: 1
    repeat: eos
    doc: TODO
