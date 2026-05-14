# LAB SHEET — WEEK 2
## Computer Networks | CDIO Framework | Undergraduate Level LAB 2

```
╔══════════════════════════════════════════════════════════════════════╗
║                                                                      ║
║   🏥  NETWORK E.R.                                                   ║
║       Emergency Room for Sick Networks                               ║
║                                                                      ║
║   PATIENT: ACME Corp's office network                                ║
║   SYMPTOMS: Broadcast storms, collision chaos, zero isolation        ║
║   YOUR ROLE: Network Medic — diagnose, treat, and discharge          ║
║                                                                      ║
║   You have 80 minutes. The patient is critical.                      ║
║                                                                      ║
╚══════════════════════════════════════════════════════════════════════╝
```

---

## The Incident Report

**Received:** Monday 08:30 — ACME Corp IT emergency hotline

> *"Our entire office network has been crawling since last week. File transfers time out, video calls drop, and we keep seeing strange packets on the network analyzer. We have 6 departments, 200 employees, everything on one network, connected through old hubs we bought in 2005. Please help."*

You arrive on site and find the following:

- **6 PCs** representing 3 departments: Finance (F), Engineering (E), Management (M)
- **All connected through a single HUB** — one collision domain, one broadcast domain
- **No VLANs, no segmentation** — Finance data is visible to Engineering, Management to all
- **Static IPs assigned:** All on `10.0.0.0/24`

**Your mission:** Diagnose the problem, design the fix, implement it, and verify the patient has recovered.

---

## Tools & Setup

| | |
|---|---|
| **Simulator** | Cisco Packet Tracer (Realtime mode) |
| **Lab file** | Create network diagram then save as`week2_er.pkt` |

---

## 🩺 TRIAGE — Open the Patient File (5 min)

Create network diagram in packet tracer then save as`week2_er.pkt`  The diagram in text as below:

```
                        [HUB]
                       / | \ \\ \
                      /  |  \  \\ \
                   [F1] [F2] [E1] [E2] [M1] [M2]
                Finance  Finance  Eng  Eng   Mgmt Mgmt

All IPs pre-configured:
F1=10.0.0.1, F2=10.0.0.2, E1=10.0.0.3, E2=10.0.0.4
M1=10.0.0.5, M2=10.0.0.6
```

Before touching anything, take the patient's vitals.

**✅ Checkpoint T1 — Initial connectivity test:**

Assign IPs for all hosts then from F1, open the command prompt and ping every other host:

```
> ping 10.0.0.2
> ping 10.0.0.3
> ping 10.0.0.4
> ping 10.0.0.5
> ping 10.0.0.6
```

**📋 Record ping results:**

| From F1 → | IP | Result (Success/Fail) |
|-----------|----|-----------------------|
| F2 | 10.0.0.2 | |
| E1 | 10.0.0.3 | |
| E2 | 10.0.0.4 | |
| M1 | 10.0.0.5 | |
| M2 | 10.0.0.6 | |

---

## 🔬 DIAGNOSIS — Map the Pathology (10 min)

Before prescribing a treatment, you must understand exactly what is wrong. A good doctor doesn't guess.

**✅ Checkpoint D1 — Domain mapping:**

Identify computers that belong to the same collision/broadcast domain, then list them :
- Collision domain:
- Broadcast domain:

**📋 Fill in the diagnosis:**

| Symptom | Your Measurement |
|---------|-----------------|
| Number of collision domains in current network | |
| Number of broadcast domains in current network | |
| If F1 sends a broadcast — which PCs receive it? | |
| If M1 sends a file to M2 — which PCs can "see" this traffic? | |

**The diagnosis in one sentence:**

> *The ACME network suffers from \_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_ — all 6 PCs share a single \_\_\_\_\_\_\_\_\_\_\_\_\_\_ domain and a single \_\_\_\_\_\_\_\_\_\_\_\_\_\_\_ domain.*

---

## 💊 PRESCRIBE — Design the Treatment (5 min)

Before touching any equipment, you must write a treatment plan. (This is the CDIO Design phase.)

**Treatment Plan:**

| VLAN ID | Name | Assigned Hosts | Ports |
|---------|------|---------------|-------|
| VLAN 10 | Finance | F1, F2 | SW Fa0/1, Fa0/2 |
| VLAN 20 | Engineering | E1, E2 | SW Fa0/3, Fa0/4 |
| VLAN 30 | Management | M1, M2 | SW Fa0/5, Fa0/6 |

**✅ Checkpoint P1 — Sign your prescription:**  
Write the expected outcome of your treatment:

> *"After the upgrade: the network will have \_\_\_\_\_ collision domains and \_\_\_\_\_ broadcast domains. Finance PCs can ping each other but \_\_\_\_\_\_\_\_\_\_\_\_\_\_\_ reach Engineering PCs without a router."*

---

## 🔧 SURGERY — Perform the Upgrade (25 min)

**Step 1 — Replace the hub with a switch**

In Packet Tracer:
1. Delete the HUB from the topology
2. Add a **Cisco 2960 switch** from the device panel
3. Reconnect all 6 PCs to the switch (use **Copper Straight-Through** cables):
   - F1 → Fa0/1 · F2 → Fa0/2 · E1 → Fa0/3 · E2 → Fa0/4 · M1 → Fa0/5 · M2 → Fa0/6

---

**Step 2 — Create VLANs on the switch**

Click the switch → CLI tab. Enter the following configuration:

```
SW> enable
SW# configure terminal
SW(config)# ! StudentID: XXXXXXXX    ← replace with your ID

SW(config)# vlan 10
SW(config-vlan)# name Finance
SW(config-vlan)# exit

SW(config)# vlan 20
SW(config-vlan)# name Engineering
SW(config-vlan)# exit

SW(config)# vlan 30
SW(config-vlan)# name Management
SW(config-vlan)# exit
```

**✅ Checkpoint S1 — Verify VLANs exist:**

```
SW# show vlan brief
```

```
┌──────────────────────────────────────────────────────────────────┐
│  SW# show vlan brief                                             │
│                                                                  │
│  VLAN  Name          Status    Ports                             │
│  ────  ────────────  ────────  ──────────────────                │
│                                                                  │
│                                                                  │
│                                                                  │
└──────────────────────────────────────────────────────────────────┘
```

Are VLAN 10, 20, and 30 listed? \_\_\_\_\_ (Yes/No)

---

**Step 3 — Assign ports to VLANs**

```
SW(config)# interface FastEthernet0/1
SW(config-if)# switchport mode access
SW(config-if)# switchport access vlan 10
SW(config-if)# exit

SW(config)# interface FastEthernet0/2
SW(config-if)# switchport mode access
SW(config-if)# switchport access vlan 10
SW(config-if)# exit

SW(config)# interface FastEthernet0/3
SW(config-if)# switchport mode access
SW(config-if)# switchport access vlan 20
SW(config-if)# exit

SW(config)# interface FastEthernet0/4
SW(config-if)# switchport mode access
SW(config-if)# switchport access vlan 20
SW(config-if)# exit

SW(config)# interface FastEthernet0/5
SW(config-if)# switchport mode access
SW(config-if)# switchport access vlan 30
SW(config-if)# exit

SW(config)# interface FastEthernet0/6
SW(config-if)# switchport mode access
SW(config-if)# switchport access vlan 30
SW(config-if)# exit

SW(config)# end
SW# copy running-config startup-config
```

**✅ Checkpoint S2 — Verify port assignments:**

```
SW# show vlan brief
```

| VLAN | Expected Ports | Actual Ports (from output) | Match? |
|------|---------------|---------------------------|--------|
| 10 Finance | Fa0/1, Fa0/2 | | Y/N |
| 20 Engineering | Fa0/3, Fa0/4 | | Y/N |
| 30 Management | Fa0/5, Fa0/6 | | Y/N |

---

## 🩺 VITAL SIGNS — Verify Recovery (15 min)

**✅ Checkpoint V1 — Intra-VLAN pings (should SUCCEED):**

| Test | Expected | Result |
|------|---------|--------|
| F1 → F2 (VLAN 10) | ✅ Success | |
| E1 → E2 (VLAN 20) | ✅ Success | |
| M1 → M2 (VLAN 30) | ✅ Success | |

**✅ Checkpoint V2 — Inter-VLAN pings (should FAIL):**

| Test | Expected | Result |
|------|---------|--------|
| F1 → E1 (cross-VLAN) | ❌ Fail | |
| F1 → M1 (cross-VLAN) | ❌ Fail | |
| E1 → M1 (cross-VLAN) | ❌ Fail | |

> 💡 Cross-VLAN pings succeed? → Re-check port assignments with `show vlan brief`. Ports may still be on VLAN 1.

**✅ Checkpoint V3 — The MAC Table Oracle:**

```
SW# show mac address-table
```

Copy the output:

```
┌──────────────────────────────────────────────────────────────────────┐
│  Vlan   Mac Address         Type       Ports                         │
│  ────   ─────────────────── ────────   ─────                         │
│                                                                      │
│                                                                      │
│                                                                      │
│                                                                      │
└──────────────────────────────────────────────────────────────────────┘
```

**(a)** How many entries? \_\_\_\_\_ &emsp; **(b)** Any VLAN 10 entry under VLAN 20/30? \_\_\_\_ (Y/N)

**(c)** What does separate MAC tables per VLAN tell you about Layer 2 isolation?

&emsp;\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_

**✅ Checkpoint V4 — Post-surgery domain count:**

| | Before (Hub) | After (Switch + VLANs) |
|--|-------------|------------------------|
| Collision domains | | |
| Broadcast domains | | |

---

## 📋 DISCHARGE SUMMARY 

**R1.** Cross-VLAN pings failed even though both PCs are on `10.0.0.x/24`. Explain why same-subnet IPs cannot reach each other across VLANs.

&emsp;\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_

**R2.** Before upgrade, F1→F2 traffic — which PCs saw it on the hub? After upgrade? What changed at the switch level?

&emsp;Before: \_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_ &emsp; After: \_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_  
&emsp;What changed: \_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_

**R3.** Finance now needs access to a server on the Engineering VLAN. What Layer 3 device is needed and what is the configuration called?

&emsp;Device: \_\_\_\_\_\_\_\_\_\_\_\_\_ &emsp; Config name: \_\_\_\_\_\_\_\_\_\_\_\_\_ &emsp; Covered in Week: \_\_\_\_\_

**R4.** Label each lab stage with its CDIO phase:

| What you did | CDIO Phase |
|-------------|-----------|
| Read incident report, mapped domains | \_\_\_\_\_ |
| Filled in the Treatment Plan table | \_\_\_\_\_ |
| Configured VLANs on the switch | \_\_\_\_\_ |
| Ping tests + MAC table verification | \_\_\_\_\_ |

---

## 🏆 BONUS ROUNDS

**Bonus A — Two-Switch Trunk** 
Add SW2, connect SW1 Fa0/24 ↔ SW2 Fa0/24. Add F3 on SW2 VLAN 10. Configure trunk on both. Can F1 ping F3? \_\_\_\_ Why? \_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_

**Bonus B — Flooded Detective   
Enable Simulation Mode. Filter ARP only. Ping F1→E1 (cross-VLAN, should fail). Observe:

- ARP leaves F1's port? \_\_\_\_ | Flooded to which ports? \_\_\_\_\_\_\_\_\_ | E1 receives ARP? \_\_\_\_
- Why does ping fail even though ARP was flooded? \_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_

**Bonus C — Port Security**

```
SW(config)# interface FastEthernet0/1
SW(config-if)# switchport port-security
SW(config-if)# switchport port-security maximum 1
SW(config-if)# switchport port-security violation shutdown
```

Connect a second PC to Fa0/1. What happens? \_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_  
What attack does this defend against? \_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_

---

## 📊 Score Card

| Checkpoint | Description | Max Pts |
|-----------|-------------|---------|
| T1 | Triage ping results | 4 |
| D1 | Domain mapping diagram (pre-surgery) | 6 |
| P1 | Treatment plan | 2 |
| S1 | VLANs verified | 6 |
| S2 | Port assignments verified | 8 |
| V1 | Intra-VLAN pings succeed | 6 |
| V2 | Inter-VLAN pings fail | 8 |
| V3 | MAC table read and interpreted | 8 |
| V4 | Before/after domain diagram | 6 |
| DS1 | Discharge summary (4 questions) | 6 |
| **Subtotal** | | **60** |
| Bonus A | Trunk between two switches | 4 |
| Bonus B | Simulation mode ARP observation | 4 |
| Bonus C | Port security | 3 |
| **Total possible** | | **71** |

---

## Submission
1. Zip file that comprises Packet Tracer file pkt, and
2. Week_2_report(docx)

---

## IOS Quick Reference

```
SW# show vlan brief                          ! List VLANs + ports
SW# show mac address-table                   ! CAM table
SW# show interfaces status                   ! Port speed, duplex, VLAN
SW(config)# vlan 10                          ! Create VLAN
SW(config-vlan)# name Finance
SW(config)# interface Fa0/1
SW(config-if)# switchport mode access        ! Access port
SW(config-if)# switchport access vlan 10     ! Assign VLAN
SW(config-if)# switchport mode trunk         ! Trunk port
SW(config-if)# switchport trunk allowed vlan all
SW# copy running-config startup-config       ! Save config
```

---

*Lab Sheet — Week 2 | Network E.R. | Computer Networks | CDIO Framework | v1.1*
